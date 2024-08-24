import { useState } from 'react';

const Content = () => {
  const [selectedDeckToLearn, setDeckToLearn] = useState("");

  return <div>{selectedDeckToLearn === "" ? <DeckList selectDeckToLearnFn={setDeckToLearn} /> : <div></div>}</div>
}

function App() {
  return <Content />;
}

export default App
