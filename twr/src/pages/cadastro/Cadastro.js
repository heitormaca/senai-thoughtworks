import React, {Component} from 'react';
import { BrowserRouter as Link } from "react-router-dom";








class Cadastro extends Component{

    constructor(props){
        super(props);
        this.state = {
            nomeUsuario: '',
            nomeCompleto: '',
            email: '',
            senha: ''
        }

        this.cadastrarUsuario = this.cadastrarUsuario.bind(this);
        this.atualizaEstadoNome = this.atualizaEstadoNome.bind(this);
        this.atualizaEstadoNomeCompleto = this.atualizaEstadoNomeCompleto.bind(this);
        this.atualizaEstadoEmail = this.atualizaEstadoEmail.bind(this);
        this.atualizaEstadoSenha = this.atualizaEstadoSenha.bind(this);
    }

    atualizaEstadoNome(event){
        this.setState({nomeUsuario:event.target.value})
    }

    
    atualizaEstadoNomeCompleto(event){
        this.setState({nomeCompleto:event.target.value})
    }

    
    atualizaEstadoEmail(event){
        this.setState({email:event.target.value})
    }

    
    atualizaEstadoSenha(event){
        this.setState({senha:event.target.value})
    }


    // componentDidMount(){
    // this.cadastrarUsuario();
    // }

    cadastrarUsuario(event){
        event.preventDefault();
        fetch('https://localhost:5001/api/Usuario', {
            method: 'POST',
            body: JSON.stringify({
            nomeUsuario: this.state.nomeUsuario,
            nomeCompleto: this.state.nomeCompleto,
            email: this.state.email,
            senha: this.state.senha
            }),
            headers: {'Content-type': 'application/json'}
        })
        
        .then(resposta => {
            if (resposta.status === 200) {
                console.log('Cadastro de usuário concluído com sucesso') 
                window.location.href ="../Bem vindo"
            }
        })
    }

    render(){
        return(
            <div>
                
<body>
    <main>
        <section id="corpo-1-login">
            <div id="relativo-c2-login"></div>
            <div id="relativo-c-login"></div>
            <div id="relativo-login">
            </div>
            <section id="conteudo-2-login">

                <div id="titulo-3-login">
                    <h1>Cadastro</h1>
                  
                </div>
                <section id="conteudo-3-login">

                    <div id="imagem-principal-4-login">
                        {/* <img src="Imagem/fotologin.png" alt="Imagem com uma jovem mulher apoiada em um cartão genérico identificador com detalhes pretos e azuis"> */}
                    </div>
                    <div class="imagem2">
                        {/* <img src="Imagem/plantatablet.png" alt="Imagem de uma planta no lado esquerdo da tela"> */}
                    </div>
                    <div id="inserir-dados-4-login">
                        <form onSubmit={this.cadastrarUsuario}>
                            <label type="text">nome:</label>
                            <input type="text" 
                            value={this.state.nome}
                            onChange={this.atualizaEstadoNome}
                            required />
                            <label type="text">nome completo:</label>
                            <input type="text" required 
                            value={this.state.nomeCompleto}
                            onChange={this.atualizaEstadoNomeCompleto}
                            />
                            <label type="text">Email:</label>
                            <input type="text" required 
                            value={this.state.email}
                            onChange={this.atualizaEstadoEmail}
                            />
                            <label type="text">Senha:</label>
                            <input type="password" required 
                            value={this.state.senha}
                            onChange={this.atualizaEstadoSenha}
                            />


                            <button type="submit"  onClick="cadastrarUsuario()" id="entrar-5-login"  > <Link to="/pages/login"> Entrar</Link></button>

                        </form>
                        <div class="opcoes-fim2-3-login">
                            <ul>
                                <li><a href="#">Cadastre-se</a></li>
                                <li><a href="#">Esqueceu a senha?</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="imagem3">
                        {/* <img src="Imagem/Login_Desktop__1_@1x (1).png" alt=""> */}
                    </div>
                </section>
            </section>
        </section>
    </main>
</body>
            </div>
        )
    }
}

export default Cadastro;