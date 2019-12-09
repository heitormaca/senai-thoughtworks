import React, {Component} from 'react';
import Axios from 'axios';
import { parseJwt } from '../services/auth';

class Login extends Component{

    constructor(props){
      super(props);
      this.state = {
        email : '',
        senha : '',
        erroMensagem : '',
        isLoading : false
      }
    }

    efetuaLogin(event){

      
      event.preventDefault();
      this.setState({erroMensagem : ''})
      this.setState({isLoading : true });

      Axios.post('https://localhost:5001/api/login', 
            
      {  email : this.state.email, senha : this.state.senha                                        
      }).then(data => {
      
        if (data.status === 200){
        localStorage.setItem('autenticar', data.data.token)
        this.setState({isLoading : false});

        var base64 = localStorage.getItem('autenticar').split('.')[1];

        console.log(parseJwt().Role)
        // window.location.href ="/"
        if (parseJwt().Role === 'Administrador') {
          this.props.history.push('./DashUsuario')
        }else{
          this.props.history.push('/')
        }

      }})
    .catch(erro => {
      this.setState({erroMensagem : 'E-mail ou senha inválidos!'})
      this.setState({isLoading : false});
    });
  
  }

  atualizaStateCampo(event){
    this.setState({ [event.target.name] : event.target.value })
    this.setState()
  }

  

    render(){
      return(
        <div>

<body>
    <section>
          <form onSubmit={this.efetuaLogin.bind(this)}>
            <div className="item">
              <input
                placeholder="username"
                value={this.state.email}
                onChange={this.atualizaStateCampo.bind(this)}
                className="input__login"
                type="text"
                name="email"
                id="login__email"
              />
            </div>
            <div className="item">
              <input
                placeholder="password"
                value={this.state.senha}
                onChange={this.atualizaStateCampo.bind(this)}
                className="input__login"
                type="password"
                name="senha"
                id="login__password"/>
            </div>
            <div className="item">
            
            <p style={{ color : 'red' }}>{this.state.erroMensagem}</p>

          {
              this.state.isLoading === false &&
              <button type="submit" className="btn btn__login" id="btn__login">Login</button>
          }

          {
          this.state.isLoading === true &&
          <button type="submit" disabled>Carregando...</button>
          }


            </div>                
          </form>

    </section>

 
  </body>

        </div>
      )
    }
  }

export default Login;