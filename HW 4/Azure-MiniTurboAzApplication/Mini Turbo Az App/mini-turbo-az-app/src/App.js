import './App.css';
import Books from './Books';
import Book from './Book';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
function App() {
  return (
    <BrowserRouter>
      <div className="app">
        <Routes>
          <Route path='/' element={<Books />} />

          <Route path='/Book/:id' element={<Book />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
