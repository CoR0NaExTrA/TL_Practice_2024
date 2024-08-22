bool usingDictionary = true;
Dictionary<string, string> wordsDictionary = new();
wordsDictionary = LoadDictionaryFromFile( "Dictionary.txt" );

Console.WriteLine( "Dictionary" );
PrintCommands();

while ( usingDictionary )
{
    Console.Write( "Введите команду: " );
    switch ( Console.ReadLine().Trim().ToLower() )
    {
        case "exit":
            Console.WriteLine( "Завершаем работу и сохраняем словарь..." );
            usingDictionary = false;
            break;
        case "addtranslation":
            AddTranslation( wordsDictionary );
            break;
        case "translate":
            TryTranslate( wordsDictionary );
            break;
        default:
            Console.WriteLine( "Неизвестная команда!" );
            PrintCommands();
            break;
    }
}
SaveDictionaryToFile( wordsDictionary );

Dictionary<string, string> LoadDictionaryFromFile( string filePath )
{
    Dictionary<string, string> dictionary = new();
    try
    {
        StreamReader sr = new StreamReader( filePath );
        string line;
        while ( ( line = sr.ReadLine() ) != null )
        {
            string[] words = line.Split( ":" );
            if ( ( words[ 0 ] != null ) && ( words[ 1 ] != null ) )
            {
                dictionary.Add( words[ 0 ], words[ 1 ] );
            }
        }
        sr.Close();
    }
    catch ( Exception e )
    {
        Console.WriteLine( $"Ошибка при работе с файлом: {e.Message}" );
    }
    return dictionary;
}

static string GetNotEmptyString( string value )
{
    Console.Write( $"Введите {value}: " );
    string str = Console.ReadLine();
    while ( string.IsNullOrWhiteSpace( str ) )
    {
        Console.WriteLine( "Поле не должно быть пустым, введите его еще раз" );
        str = Console.ReadLine();
    }
    return str;
}

void AddTranslation( Dictionary<string, string> dictionary )
{
    string word = GetNotEmptyString( "слово" );
    if ( dictionary.ContainsKey( word ) )
    {
        Console.WriteLine( $"Упс! Слово \"{word}\" уже есть в словаре!" );
        Console.WriteLine( $"Используйте команду \"translate\" чтобы увидеть его перевод" );
    }
    else
    {
        string translation = GetNotEmptyString( "перевод слова" );
        dictionary.Add( word, translation );
    }
}

void TryTranslate( Dictionary<string, string> dictionary )
{
    const string positiveAnser = "y";
    string word = GetNotEmptyString( "слово" );
    if ( dictionary.ContainsKey( word ) )
    {
        Console.WriteLine( $"Слово \"{word}\" переводится как \"{dictionary[ word ]}\"" );
    }
    else
    {
        Console.Write( $"Слова \"{word}\" нет в словаре, хотите добавить перевод({positiveAnser}/n): " );
        if ( Console.ReadLine() == positiveAnser )
        {
            string translation = GetNotEmptyString( "перевод слова" );
            dictionary.Add( word, translation );
        }
    }
}

void SaveDictionaryToFile( Dictionary<string, string> dictionary )
{
    if ( File.Exists( "Dictionary.txt" ) )
    {
        File.Delete( "Dictionary.txt" );
    }

    StreamWriter sw = new StreamWriter( "Dictionary.txt" );
    foreach ( var pair in dictionary )
    {
        sw.WriteLine( $"{pair.Key}{":"}{pair.Value}" );
    }
    sw.Close();
}

void PrintCommands()
{
    Console.WriteLine( "translate - перевести слово" );
    Console.WriteLine( "addTranslation - добавить перевод" );
    Console.WriteLine( "exit - выход" );
}
