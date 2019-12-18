import React, {Component} from 'react';
import iconeComp from '../../../assets/img/laptop.png';
import iconeUser from '../../../assets/img/user.png';
import iconeFile from '../../../assets/img/file.png';
import iconeCat from '../../../assets/img/categorias.png';
import iconeLogout from '../../../assets/img/logout.png';
import temaDeFundo from '../../../assets/img/semtitulo.png';
import './listarInteresses.css';


class listarInteresses extends Component{

    constructor(props){
        super(props)
        this.state = {
            idClassificado: '',
            idInteresse: '',
            classificado: [],
            interessados: [],
            // comprador: '',
            compra: []
        }
        this.cutUrlInt = this.cutUrlInt.bind(this)
        this.buscarClassificadoId = this.buscarClassificadoId.bind(this)
        this.buscarInteressados = this.buscarInteressados.bind(this)
        this.atualizaCompra = this.atualizaCompra.bind(this)
    }

    // atualizaCompra(event){
    //     this.setState({comprador : event.target.value})
    // }

    async componentDidMount(){
        await this.cutUrlInt()
        this.buscarClassificadoId()
        this.buscarInteressados()
    }

    cutUrlInt(){
        var url = window.location.href
        var id = url.split('=')[1]
        this.setState({ idClassificado : id })
    }

    // aprovarCompra(){
    //     fetch('https://localhost:5001/api/interesse/' + this.state.idInteresse + '/vender', {
    //         method:'PUT',
    //         headers: {
    //             "Content-Type": "application/json",
    //             "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
    //                 }
    //     })
    //     .then(resposta => resposta.json())  
    //     .then(data => {this.setState({ compra : data })
    //     ;console.log(this.state.compra)}
    //     ).catch((erro) => console.log(erro))
    // }

    buscarClassificadoId(){
        fetch('https://localhost:5001/api/classificado/' + this.state.idClassificado, {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                    }
        })
        .then(resposta => resposta.json())  
        .then(data => {this.setState({ classificado : data })
        ;console.log(this.state.classificado)}
        ).catch((erro) => console.log(erro))
    }

    buscarInteressados(){
        fetch('https://localhost:5001/api/classificado/'+ this.state.idClassificado + '/interesse', {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                    }
        })
        .then(resposta => resposta.json())  
        .then(data => {this.setState({ interessados : data })
        }
        ).catch((erro) => console.log(erro))
    }
    
   

    render(){

        return(

            <div>


<body>  
    <header class="fixed">
        <div id="menu_header_lateral_esquerda_adm">
            <div id="icon_menu_header_adm"><i class="fas fa-bars"></i></div>

            <div id="campo_busca_header_adm">
                <i id="icon_campo_busca_header_adm" class="fas fa-search"></i>
                <form action="">
                    <input type="text" value="" placeholder="Buscar usuário"/>
                </form>
            </div>
        </div>

        <div id="menu_header_lateral_direita_adm">
            <p>Victor Costa</p>

            <div id="img_menu_header_adm">
                <p>V</p>
            </div>
        </div>
    </header>

    <main id="conteudo_adm">
        <nav id="menu_lateral_esquerda_adm">
            <div class="identificador_menu_lateral_adm">
                <div class="identificador_menu_lateral_cor_adm"></div>
                <div class="icon_menu_lateral_adm">
                    <img src={iconeFile} alt="ícone de usuário"/>
                </div>
            </div>
            <div class="icon_menu_lateral_adm">
                <img src={iconeComp} alt="ícone de equipamentos"/>
            </div>
            <div class="icon_menu_lateral_adm">
                <img src={iconeUser} alt="ícone de classificados"/>
            </div>
            <div class="icon_menu_lateral_adm">
                <img src={iconeCat} alt="ícone de categorias"/>
            </div>
            <div class="icon_menu_lateral_adm">
                <img src={iconeLogout} alt="ícone de saída"/>
            </div>
        </nav>

        <section id="conteudo_tela_lateral_direita_adm">
            <div id="cabecalho_corpo_adm">
                <p>Usuários</p>
            </div>
            <div id="corpo_conteudo_adm">
                <div id="limitacao_espaco_corpo_conteudo_adm">
                    <div id="conteudo_add_classificado_adm">
                        <div id="margin_tela_add_classificado_adm">
                            <div id="imagens_do_classificado">
                                <div>
                                    <div id="style_add_img_adm" style={{position: "relative", display: "inline-block"}}>
                                        <input id="input_add_img_adm" type="file" change="onFileChange" style={{position: "absolute", left:"0", top:"0", opacity: "0" }} />
                                    </div>
                                    <div id="imagens_do_classificado_baixa">
                                        <div id="style_add_img_baixa_adm" style={{position: "relative", display: "inline-block"}}>
                                            <input id="input_add_img_classificado_baixa_adm" type="file" change="onFileChange" style={{position: "absolute", left:"0", top:"0", opacity: "0" }} />
                                        </div>
                                        <div id="style_add_img_baixa_adm" style={{position: "relative", display: "inline-block"}}>
                                            <input id="input_add_img_classificado_baixa_adm" type="file" change="onFileChange" style={{position: "absolute", left:"0", top:"0", opacity: "0" }} />
                                        </div>
                                        <div id="style_add_img_baixa_adm" style={{position: "relative", display: "inline-block"}}>
                                            <input id="input_add_img_classificado_baixa_adm" type="file" change="onFileChange" style={{position: "absolute", left:"0", top:"0", opacity: "0" }} />
                                        </div>
                                        <div id="style_add_img_baixa_adm" style={{position: "relative", display: "inline-block"}}>
                                            <input id="input_add_img_classificado_baixa_adm" type="file" change="onFileChange" style={{position: "absolute", left:"0", top:"0", opacity: "0" }} />
                                        </div>
                                    </div>
                                </div>
                                <div id="div_uiop_32">
                                    <div>
                                        <form id="inputs_classificado_01">
                                            <div class="formatando_input">
                                                <label class="label" for=""><b>preço</b></label>
                                                <p class="input_classificado_adm">R$ {this.state.classificado.preco}</p>
                                            </div>
                                            <div class="formatando_input">
                                                <label class="label" for=""><b>número de série</b></label>
                                                <p class="input_classificado_adm">{this.state.classificado.numeroDeSerie}</p>
                                            </div>
                                            <div class="formatando_input">
                                                <label class="label" for=""><b>código</b></label>
                                                <p class="input_classificado_adm">{this.state.classificado.codigoClassificado}</p>
                                            </div>
                                            <div class="formatando_input">
                                                <label class="label" for=""><b>fim da vida util</b></label>
                                                <p class="input_classificado_adm">{this.state.classificado.fimDeVidaUtil}</p>
                                            </div>
                                        </form>
                                    </div>
                                    <div>
                                        <form class="inputs_classificado_02" action="">
                                            <div class="formatando_input" style={{display: "flex"}}>
                                                <label class="label" for=""><b>data de fabricação</b></label>
                                                <p class="input_classificado_adm">{this.state.classificado.dataFabricacao}</p>
                                            </div>
                                        </form>
                                    </div>
                                    <div>
                                        <form class="inputs_classificado_02" action="">
                                            <div class="formatando_input">
                                                <label class="label" for=""><b>Softwares inclusos</b></label>
                                                <p class="input_classificado_adm" style={{width: "100%", height: "54px"}}>{this.state.classificado.softwaresInclusos}</p>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <form action="" class="inputs_classificado_02" style={{marginLeft: "0"}}>
                                    <div class="formatando_input">
                                        <label class="label" for=""><b>avaliação</b></label>
                                        <p class="input_classificado_adm" style={{width: "100%", height: "15.625em"}}>{this.state.classificado.avaliacao}</p>

                                    </div>
                                </form>
                            </div>
                            <div>
                                <hr style={{width: "100%", marginTop: "30px", border: "0.5px solid rgba(255, 255, 255, 0.137)"}}/>
                            </div>
                            <div style={{marginTop: "25px"}}>
                                <p><b style={{color: "#fff", textTransform: "uppercase"}}>interessados</b></p>

                                {this.state.interessados.map( item => {
                                    return(
                                    <div class="user_interessado" key={item.idUsuarioNavigation.idUsuario}>
                                    <div class="fotoUser">
                                    </div>
                                    <div class="nomeUser">
                                        <p>{item.idUsuarioNavigation.nomeUsuario}</p>
                                    </div>
                                    <div class="nomeCompletoUser">
                                        <p>{item.idUsuarioNavigation.nomeCompleto}</p>
                                    </div>
                                    <div class="emailUser">
                                        <p>{item.idUsuarioNavigation.email}</p>
                                    </div>
                                    <div class="botaoUser">
                                        {/* <button type="submit" onClick={a => this.aprovarCompra(compra.idInteresse)}  style={{cursor:"pointer"}}>Definir Comprador</button> */}
                                    </div>
                                </div>
                                )})}
                                
                        </div>
                    </div>
                </div>
                </div>
                </div>
        </section>
        </main>

    </body>



            </div>
            
                )
            
        }
}


export default listarInteresses;