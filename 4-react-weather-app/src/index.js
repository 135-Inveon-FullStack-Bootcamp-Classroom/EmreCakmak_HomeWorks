import React from 'react';
import ReactDOM from 'react-dom';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import 'regenerator-runtime/runtime.js';
import App from './containers/app';
import reducer from './reducers/';
import './css/main.css';

const initialState = [];

const store = createStore(reducer, initialState, applyMiddleware(thunk));

ReactDOM.render(<App store={store} />, document.getElementById('root'));
