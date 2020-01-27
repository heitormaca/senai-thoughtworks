import React, { Component } from 'react';
import iconeUser from '../../../assets/img/user.png';
import iconeLaptop from '../../../assets/img/laptop.png';
import iconeFile from '../../../assets/img/file.png';
import iconeCat from '../../../assets/img/categorias.png';
import iconeLogout from '../../../assets/img/logout.png';
import temaDeFundo from '../../../assets/img/semtitulo.png';
import CabecalhoADM from '../../../componentes/cabecalhoADM/CabecalhoADM'

class listarEquipamentoClassificado extends Component {
    constructor(props) {
        super(props);
        this.state = {
            equipamento: [],
            loading: false
        }
        this.encaminharEquipamento = this.encaminharEquipamento.bind(this)
		this.buscarEquipamentos = this.buscarEquipamentos.bind(this)
    }

    encaminharEquipamento(id){
        window.location.href = '/cadastrarClassificado?=' + id
    }

    buscarEquipamentos() {
        this.setState({ loading: true });
        fetch('https://localhost:5001/api/Equipamento', {
        headers: {
            "Content-Type": "application/json",
            "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                }                                        }
            )
            .then(resposta => resposta.json())
            .then(data => {
                this.setState({ equipamento: data })
                this.setState({ loading: false });
            })
            .catch((erro) => console.log(erro))
    }
        
    componentDidMount() {
        this.buscarEquipamentos();
    }    
    render() {
        return (
            <div>
                <body id="corpoUser-10">
                    <CabecalhoADM/>
                </body>
            </div>
        )                
    }
}
export default listarEquipamentoClassificado;

{/* <body style ={{ 
backgroundImage: "url(" + temaDeFundo + ")",
backgroundRepeat: "no-repeat",
backgroundAttachment: "fixed",
background: "cover",
backgroundSize: "100%, 60em"}} >
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
    <nav id="menu_lateral_esquerda_adm" style={{height:""}}>
        <div class="identificador_menu_lateral_adm">
            <div class="identificador_menu_lateral_cor_adm"></div>
            <div class="icon_menu_lateral_adm">
            <a href="./listarEquipamento">   <img src={iconeLaptop} alt="ícone de um laptop"/> </a>
            </div>
        </div>
        <div class="icon_menu_lateral_adm">
        <a href="./listarClassificado">  <img src={iconeFile} alt="ícone de equipamentos"/></a>
        </div>
        <div class="icon_menu_lateral_adm">
        <a href="./DashUsuario"> <img src={iconeUser} alt="ícone de classificados"/></a>
        </div>
        <div class="icon_menu_lateral_adm">
        <a href="./listarCategoria"> <img src={iconeCat} alt="ícone de categorias"/></a>
        </div>
        <div class="icon_menu_lateral_adm">
         <img src={iconeLogout} alt="ícone de saída"/>
        </div>
    </nav>

    <section id="conteudo_tela_lateral_direita_adm">
        <div id="cabecalho_corpo_adm">
            <p>Equipamentos cadastrados</p>
        </div>
        <div id="corpo_conteudo_adm">
            <div id="limitacao_espaco_corpo_conteudo_adm" style={{height:"70em"}}>
                <div id="sombra_tabela_adm">
                    <table id="tabela_usuarios_adm">
                        <thead>
                            <tr>
                                <th>
                                    <a href="#">
                                        marca
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        nome
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        modelo
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        s.o.
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        processador
                                    </a>
                                </th>
                            </tr>
                        </thead>
                        {this.state.equipamento.map( Equipamento => {
                            return (
                        <tbody>
                            <br/>

                            <tr  key={Equipamento.idEquipamento}  style={{marginTop:"2em"}}>
                                <td  id="nome_usuario">{Equipamento.marca}</td>
                                <td style={{cursor:"pointer"}} > {Equipamento.nomeEquipamento}</td>
                                <td>{Equipamento.modelo}</td>
                                <td id="numero_compras_user">{Equipamento.sistemaOperacional}</td>
                                <td id="botao_delete">{Equipamento.processador}</td>
                                <button onClick={ () => this.encaminharEquipamento(Equipamento.idEquipamento)}>Encaminhar</button>
                            </tr>
                            
                        </tbody>
                            )                                               }
                            )
                            }
                    </table>
                </div>
            </div>
        </div>
    </section>
</main>

</body>


 */}
