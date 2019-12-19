import React, { Component } from 'react';
import iconeUser from '../../../assets/img/user.png';
import iconeLaptop from '../../../assets/img/laptop.png';
import iconeFile from '../../../assets/img/file.png';
import iconeCat from '../../../assets/img/categorias.png';
import iconeLogout from '../../../assets/img/logout.png';
import temaDeFundo from '../../../assets/img/semtitulo.png';
import './DashCadastrarClassificado.css'



class DashboardCadastrarClassificado extends Component {

    constructor(props) {
        super(props)
        this.state = {
            idEquipamento: '',
            equipamento: [],
            CodigoClassificado: 0,
            Preco: 0,
            numeroDeSerie: 0,
            fimDeVidaUtil: 0,
            imagem: null
        }
        this.cutUrl = this.cutUrl.bind(this)
        this.buscarClassificadoPorId = this.buscarClassificadoPorId.bind(this)
    }

    async componentDidMount() {
        await this.cutUrl()
        this.buscarClassificadoPorId()
    }

    cutUrl() {
        var url = window.location.href
        var id = url.split('=')[1]
        this.setState({ idEquipamento: id })
    }

    buscarClassificadoPorId() {
        fetch('https://localhost:5001/api/equipamento/' + this.state.idEquipamento, {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
            }
        })
            .then(resposta => resposta.json())
            .then(data => {
                this.setState({ equipamento: data })
                    ; console.log(this.state.equipamento.idEquipamento)
            }
            ).catch((erro) => console.log(erro))
    }

    atualizaStateCampo(event) {
        this.setState({ [event.target.name]: event.target.value })
    }

    atualizaCodigo(event) {
        this.setState({ CodigoClassificado: event.target.value })
    }

    cadastrarClassificado(event) {
        event.preventDefault()
        let cla = new FormData();
        cla.append('CodigoClassificado', this.state.CodigoClassificado)

        console.log(cla)
        
        // fetch('https://localhost:5001/api/classificado', {
        //     method: "POST",
        //     headers: { 'Content-Type': 'multipart/form-data', "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin') },
        //     body: cla
        // })
        //     .then(res => res.json())
        //     .then(data => console.log(data))
        //     .catch(err => console.log(err))

    }
    render() {
        return (
            <div>
                <body style={{
                    backgroundImage: "url(" + temaDeFundo + ")",
                    backgroundRepeat: "no-repeat",
                    backgroundAttachment: "fixed",
                    background: "cover",
                    backgroundSize: "100%, 100%"
                }}>

                    <header class="fixed">
                        <div id="menu_header_lateral_esquerda_adm">
                            <div id="icon_menu_header_adm"><i class="fas fa-bars"></i></div>

                            <div id="campo_busca_header_adm">
                                <i id="icon_campo_busca_header_adm" class="fas fa-search"></i>
                                <form action="">
                                    <input type="text" value="" placeholder="Buscar usuário" />
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
                        <nav id="menu_lateral_esquerda_adm" style={{ height: "55em" }} >
                            <div class="identificador_menu_lateral_adm">
                                <div class="identificador_menu_lateral_cor_adm"></div>
                                <div class="icon_menu_lateral_adm">
                                    <a href="./listarClassificado"> <img src={iconeFile} /> </a>
                                </div>
                            </div>
                            <div class="icon_menu_lateral_adm">
                                <a href="./DashUsuario"><img src={iconeUser} /></a>

                            </div>
                            <div class="icon_menu_lateral_adm">
                                <a href="./listarEquipamento"> <img style={{ cursor: "pointer" }} src={iconeLaptop} /></a>

                            </div>
                            <div class="icon_menu_lateral_adm">
                                <a href="./listarCategoria"><img src={iconeCat} /></a>

                            </div>
                            <div class="icon_menu_lateral_adm">
                                <img src={iconeLogout} />

                            </div>
                        </nav>

                        <section id="conteudo_tela_lateral_direita_adm">
                            <div id="cabecalho_corpo_adm">
                                <p>Cadastrar Classificado</p>
                            </div>
                            <div id="corpo_conteudo_adm" style={{ height: "60em" }}>
                                <div id="limitacao_espaco_corpo_conteudo_adm">
                                    <div id="conteudo_add_classificado_adm">
                                        <div id="margin_tela_add_classificado_adm">
                                            <div id="imagens_do_classificado">
                                                <div>
                                                    <div id="style_add_img_adm" style={{ position: "relative", display: "inline-block" }}>
                                                        <input id="input_add_img_adm" type="file" change="onFileChange"
                                                            style={{ position: "absolute", left: "0", top: "0", opacity: "0" }} />
                                                    </div>
                                                    <div id="imagens_do_classificado_baixa">
                                                        <div id="style_add_img_baixa_adm"
                                                            style={{ position: "relative", display: "inline-block" }}>
                                                            <input id="input_add_img_classificado_baixa_adm" type="file"
                                                                change="onFileChange"
                                                                style={{ position: "absolute", left: "0", top: "0", opacity: "0" }} />
                                                        </div>
                                                        <div id="style_add_img_baixa_adm"
                                                            style={{ position: "relative", display: "inline-block" }}>
                                                            <input id="input_add_img_classificado_baixa_adm" type="file"
                                                                change="onFileChange"
                                                                style={{ position: "absolute", left: "0", top: "0", opacity: "0" }} />
                                                        </div>
                                                        <div id="style_add_img_baixa_adm"
                                                            style={{ position: "relative", display: "inline-block" }}>
                                                            <input id="input_add_img_classificado_baixa_adm" type="file"
                                                                change="onFileChange"
                                                                style={{ position: "absolute", left: "0", top: "0", opacity: "0" }} />
                                                        </div>
                                                        <div id="style_add_img_baixa_adm"
                                                            style={{ position: "relative", display: "inline-block" }}>
                                                            <input id="input_add_img_classificado_baixa_adm" type="file"
                                                                change="onFileChange"
                                                                style={{ position: "absolute", left: "0", top: "0", opacity: "0" }} />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="div_uiop_32">
                                                    <div>
                                                        <form id="inputs_classificado_01">
                                                            <div class="formatando_input">
                                                                <label for=""><b>Preco</b></label>
                                                                <input class="input_classificado_adm" type="text" value={this.state.Preco} onChange={this.atualizaStateCampo.bind(this)} />
                                                            </div>
                                                            <div class="formatando_input">
                                                                <label for=""><b>número de série</b></label>
                                                                <input class="input_classificado_adm" type="text" value={this.state.numeroDeSerie} onChange={this.atualizaStateCampo.bind(this)} />
                                                            </div>
                                                            <div class="formatando_input">
                                                                <label for=""><b>código</b></label>
                                                                <input className="input_classificado_adm" type="text" value={this.state.CodigoClassificado} onChange={this.atualizaCodigo.bind(this)} />
                                                            </div>
                                                            <div class="formatando_input">
                                                                <label for=""><b>fim da vida util</b></label>
                                                                <input class="input_classificado_adm" type="text" value={this.state.fimDeVidaUtil} onChange={this.atualizaStateCampo.bind(this)} />
                                                            </div>
                                                            <button onClick={this.cadastrarClassificado.bind(this)}>Enviar</button>
                                                        </form>
                                                    </div>
                                                    {/* <div>
                                                        <form class="inputs_classificado_02" action="">
                                                            <div class="formatando_input">
                                                                <label for=""><b>data de fabricação</b></label>
                                                                <input class="input_classificado_adm" type="text" />
                                                            </div>
                                                        </form>
                                                    </div> */}
                                                    {/* <div>
                                                        <form class="inputs_classificado_02" action="">
                                                            <div class="formatando_input">
                                                                <label for=""><b>softwares inclusos</b></label>
                                                                <textarea class="input_classificado_adm" type="text"
                                                                    style={{ width: "100%", height: "54px", resize: "none", color: "#fff" }}></textarea>
                                                            </div>
                                                        </form>
                                                    </div> */}
                                                </div>
                                            </div>
                                            {/* <div>
                                                <form action="" class="inputs_classificado_02" style={{ marginLeft: "0" }}>
                                                    <div class="formatando_input">
                                                        <label for=""><b>avaliação</b></label>
                                                        <textarea class="input_classificado_adm" type="text"
                                                            style={{ width: "100%", height: "250px", resize: "none", color: "#fff" }}></textarea>
                                                    </div>
                                                </form>
                                            </div> */}
                                            <div>
                                                <hr
                                                    style={{ width: "100%", marginTop: "30px", border: "0.5px solid rgba(255, 255, 255, 0.137)" }} />
                                            </div>
                                            <div style={{ marginTop: "25px" }}>
                                                <p><b style={{ color: "#fff", textTransform: "uppercase" }}>equipamento</b></p>
                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>Nome</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.nomeEquipamento}</p>
                                                        </div>
                                                    </div>
                                                    <div class="espacamento_info">
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>ssd</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.ssd}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>marca</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.marca}</p>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>hd</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.hd}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>modelo</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.modelo}</p>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>placa de vídeo</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.placaDeVideo}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div>
                                                            <div class="mj6yt">
                                                                <p>
                                                                    <b>sistema operacional</b>
                                                                </p>
                                                            </div>
                                                            <div>
                                                                <p>{this.state.equipamento.sistemaOperacional}</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>alimentação</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.alimentacao}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div>
                                                            <div class="mj6yt">
                                                                <p>
                                                                    <b>polegada</b>
                                                                </p>
                                                            </div>
                                                            <div>
                                                                <p>{this.state.equipamento.polegada}</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div>
                                                            <p>
                                                                <b>peso</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.peso}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div class="espacamento_info">
                                                        <div>
                                                            <div class="mj6yt">
                                                                <p>
                                                                    <b>processador</b>
                                                                </p>
                                                            </div>
                                                            <div>
                                                                <p>{this.state.equipamento.processador}</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>dimensões</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.dimensoes}</p>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="formatando_paragrafos">
                                                    <div>
                                                        <div class="mj6yt">
                                                            <p>
                                                                <b>memória ram</b>
                                                            </p>
                                                        </div>
                                                        <div>
                                                            <p>{this.state.equipamento.memoriaRam}</p>
                                                        </div>
                                                    </div>
                                                </div>
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

export default DashboardCadastrarClassificado;