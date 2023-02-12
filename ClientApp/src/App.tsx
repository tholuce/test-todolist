import React from 'react';
import {Provider} from 'react-redux';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import {Home, Login, Signup, Todo} from './pages';
import { store } from './store';

function App() {
  return <Provider store={store}>
    <BrowserRouter>
    <Routes>
      <Route path='/' element={<Home />}></Route>
      <Route path='/login' element={<Login />}></Route>
      <Route path='/signup' element={<Signup />}></Route>
      <Route path='/todo' element={<Todo />}></Route>
    </Routes>
    </BrowserRouter>
  </Provider>;
}

export default App;
