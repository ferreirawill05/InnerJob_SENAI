import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Redirect, Switch} from 'react-router-dom';
import './index.css';


import Login from '../src/pages/Login/Login.jsx';
import Perfil from './pages/Perfil/Perfil.jsx';
import MeuCracha from './pages/MeuCracha/MeuCracha.jsx';
import Cracha from './pages/Cracha/Cracha.jsx';
import Listar from './pages/Listar/Listar.jsx';
import Cadastro from './pages/Cadastro/Cadastro.jsx';
import NotFound from './pages/NotFound/NotFound.js';


import reportWebVitals from './reportWebVitals';
import permissao from './pages/Permissao/Permissao';



const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route path="/perfil" component={Perfil} />
        <Route path="/permissao" component={permissao} />
        <Route path="/cadastro" component={Cadastro} />
        <Route path="/listar" component={Listar} />
        <Route path="/meucracha" component={MeuCracha} />
        <Route path="/cracha" component={Cracha} />
        <Route path="/notFound" component={NotFound} /> 
        <Redirect to="/notFound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
