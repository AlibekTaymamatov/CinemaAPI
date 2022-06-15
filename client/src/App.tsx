import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import logo from './logo.svg';
import './App.css';
import multiActionAreaCard from './Components/CardFilms';

const App: React.FC = () => (
  <div className="App">
    <Route path="multiActionAreaCard/" exact component={multiActionAreaCard} />
  </div>
);

export default App;
