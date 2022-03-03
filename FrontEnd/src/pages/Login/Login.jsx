import { Component } from 'react';
import api from '../../services/api';
import {parseJwt} from '../../services/auth';
import './Login.css';

export default class Login extends Component {
  constructor(props) {
    super(props)
    this.state = {
      email: 'adm@email.com',
      senha: 'adm123',
      erroMensagem: '',
      isLoading: false
    };
  };

  efetuaLogin = (event) => {
    this.setState({ erroMensagem: " ", isLoading: true })
    event.preventDefault();
    api.post('/login', {
      email: this.state.email,
      senha: this.state.senha
    })
      .then(resposta => {
        if (resposta.status === 200) {
          console.log(resposta.data.token)
          localStorage.setItem('usuario-token', resposta.data.token)
          this.setState({ isLoading: false });

          switch (parseJwt().role) {
            case '1':
              this.props.history.push('/a')
              break;
            case '2':
              this.props.history.push('/a')
              break;
            case '3':
              this.props.history.push('/a')
              break;
            default:
              this.props.history.push('/')
              break;

          }
        }
      })
      .catch(() => {
        this.setState({ isLoading: false })
        this.setState({ erroMensagem: "E-mail ou senha inválidos" })
      })
  }

  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value })
  }

  render() {
    return (
      <div className="App">
        {/* <header className="App-header">
          <span>teste</span>
        </header> */}
        <main className="main_login App-header">
          <form onSubmit={this.efetuaLogin}>
            <input
              type="text"
              name="email"
              value={this.state.email}
              onChange={this.atualizaStateCampo}
              placeholder="Email"
            />
            <input
              type="password"
              name="senha"
              value={this.state.senha}
              onChange={this.atualizaStateCampo}
              placeholder="Senha"
            />
            {
              this.state.isLoading === true && 
              <button type='submit' disabled>Loading...</button>
            }
            {
              this.state.isLoading === false && 
              <button type='submit' disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>Login</button>
            }
          </form>
          <p style={{color: 'red', fontSize: '25px'}}>{this.state.erroMensagem}</p>

        </main>
      </div>
    )
  }
}


