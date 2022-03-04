import { Component } from 'react';
import api from '../../services/api';
import { parseJwt } from '../../services/auth';
import '../../assets/css/Login.css';
import background_login from '../../assets/img/img_background_login.png'
import user from '../../assets/img/user.png'
import Header from '../../components/header/header'

export default class Login extends Component {
  constructor(props) {
    super(props)
    this.state = {
      // email: 'adm@email.com',
      // senha: 'adm123',
      // email: 'professor@email.com',
      // senha: 'professor123',
      email: 'aluno@email.com',
      senha: 'aluno123',
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
              //adm
              this.props.history.push('/cadastro')
              break;
            case '2':
              //aluno
              this.props.history.push('/meucracha')
              break;
            case '3':
              //prof
              this.props.history.push('/cracha')
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
      <div> <Header />
        <main className="container_login">
          <img className="img_banner" src={background_login} alt="bk login" />
          <div className="form_h1">
            <img className="icone_perfil-login" src={user} alt="icone perfil login" />
            <form className='formulario_login' onSubmit={this.efetuaLogin}>
              <div class="campos">
                <div class="campo">
                  <label for="">E-mail</label>
                  <input
                    type="text"
                    name="email"
                    value={this.state.email}
                    onChange={this.atualizaStateCampo}
                    placeholder="Email"
                  />
                </div>
                <div class="campo">
                  <label for="">Senha</label>
                  <input
                    type="password"
                    name="senha"
                    value={this.state.senha}
                    onChange={this.atualizaStateCampo}
                    placeholder="Senha"
                  />
                </div>
              </div>


              {
                this.state.isLoading === true &&
                <button type='submit' disabled>Carregando...</button>
              }
              {
                this.state.isLoading === false &&
                <button type='submit' disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>Entrar</button>
              }
              <p style={{ color: 'red', fontSize: '25px' }}>{this.state.erroMensagem}</p>
            </form>


          </div>


        </main>
      </div>
    )
  }
}


