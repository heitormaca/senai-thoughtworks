import React, { Component } from 'react';
import './perfil.css';
import img0 from '../../assets/img/perfil.png';
import img1 from '../../assets/img/lock.png';
import img2 from '../../assets/img/locked-padlock (1).png';
import img3 from '../../assets/img/logout.png';
import Cabecalho from '../../componentes/cabecalho/Cabecalho';
import Rodape from '../../componentes/rodape/Rodape';

// import { usuarioAutenticado } from '../services/auth';



class Perfil extends Component {


    constructor(props) {
        super(props);
        this.state = {
            gUser: [],
            altSenha: [],
            senha: '',
            loading: false
        }
        this.mostrar = this.mostrar.bind(this)
        this.userLogado = this.userLogado.bind(this)
        this.alterarSenha = this.alterarSenha.bind(this)
        this.atualizaSenha = this.atualizaSenha.bind(this)
    }

    componentDidMount() {
        this.userLogado();
    }

    logout() {
        localStorage.clear();
        // -> CHAMAR NO BOTÃO DE SAIR 

        window.location.href = './pages/Apresentacao.js';
        // -> REDIRECIONA PARA A PÁGINA DE APRESENTAÇÃO //(INSERIR O LINK DA PÁGINA)
    }


    atualizaSenha(event) {
        this.setState({ senha: event.target.value })
    }

    alterarSenha = (event) => {
        event.preventDefault();
        console.log(this.state.senha)
        // this.setState({ loading: true });
        fetch('https://localhost:5001/api/Usuario/changePassword', {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem('autenticarlogin')
            },
            body:
                JSON.stringify({ senha: this.state.senha })

        })
            .then(resposta => resposta.json())
            .then(data => {
                console.log(data)
                // this.setState({ altSenha: data })
                // this.setState({ loading: false });
            })
            .catch((erro) => console.log(erro))
    }

    userLogado() {
        this.setState({ loading: true });
        fetch('https://localhost:5001/api/Usuario/gUser', {
            headers: {
                "Content-Type": "application/json",
                'authorization': 'Bearer ' + localStorage.getItem('autenticarlogin')
            }
        })
            .then(resposta => resposta.json())
            .then(data => {
                this.setState({ gUser: data })
                this.setState({ loading: false });
            })
            .catch((erro) => console.log(erro))
    }

    mostrar() {
        var y = document.getElementById("pord");
        if (y.style.display === "none") {
            y.style.display = "block";
            document.getElementById("contorno-style").style.height = "616px ";
            document.getElementById("contorno-style").style.width = "389px";
            document.getElementById("po-ord-div-3-flex-perf").style.height = "597px";
            document.getElementById("po-ord-div-3-flex-perf").style.width = "369px";
            document.getElementById("po-ord-div-2-perf").style.height = "47em";
            document.getElementById("po-ord-div-4-flex-btn-perf").style.display = "none";
        } else {
            y.style.display = "none";
            document.getElementById("contorno-style").style.height = "359px ";
            document.getElementById("contorno-style").style.width = "389px";
            document.getElementById("po-ord-div-3-flex-perf").style.height = "339px";
            document.getElementById("po-ord-div-3-flex-perf").style.width = "369px";
            document.getElementById("po-ord-div-4-flex-btn-perf").style.display = "";
        }
    }


    render() {
        // console.log(this.state.altSenha)
        return (
            <body>
                <Cabecalho />
                <main>
                    <section id="po-ord-sec-1-perf">

                        <div id="po-ord-div-2-perf">
                            <div id="contorno-style" >

                                <input value={this.state.senha} onChange={this.atualizaSenha} required type="password" />
                                <button onClick={this.alterarSenha}>Alterar</button>


                                {/* <div id="po-ord-div-3-flex-perf" key={this.state.gUser} >

                                    <div id="po-ord-div-4-img-perf"><img src={img0} /></div>
                                    <div id="po-ord-div-4-nome-perf">
                                        {this.state.gUser.nomeUsuario}
                                    </div>
                                    <div id="po-ord-div-4-nomeCompleto-perf">
                                        {this.state.gUser.nomeCompleto}
                                    </div>
                                    <div id="po-ord-div-4-email-perf">
                                        {this.state.gUser.email}
                                    </div>
                                    <div id="po-ord-div-4-hr-perf"><hr /></div>
                                    <div id="pord">
                                        <form>
                                            <div id="pord-div-4-flex-perf">
                                                <div id="pord-div-5-h3-txt"> <h4>Segurança</h4> <img src={img1} /></div>
                                                <div id="pord-div-5-input-perf">
                                                    <label for="#">Nova senha</label>
                                                    <input value={this.state.altSenha.senha} onChange={this.alterarSenha} required type="password" />
                                                </div>
                                            </div>
                                            <div id="pord-div-5-btn-perf">
                                                <button type="submit">Confirmar</button> <button onClick={this.mostrar}>Cancelar</button>
                                            </div>
                                        </form>
                                    </div>
                                    <div id="po-ord-div-4-flex-btn-perf">
                                        <button onClick={this.mostrar}>Alterar senha <div class="btn-img"><img src={img2} /></div></button> <button> Sair <div class="btn-img"><img src={img3} /></div></button>
                                    </div>
                                </div> */}

                            </div>

                        </div>
                    </section>
                </main>
                <Rodape />
            </body>
        )
    }
}

export default Perfil;