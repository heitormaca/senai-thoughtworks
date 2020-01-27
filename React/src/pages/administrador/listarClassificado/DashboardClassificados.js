import React, {Component} from 'react';
import iconeComp from '../../../assets/img/laptop.png';
import iconeUser from '../../../assets/img/user.png';
import iconeFile from '../../../assets/img/file.png';
import iconeCat from '../../../assets/img/categorias.png';
import iconeLogout from '../../../assets/img/logout.png';
import temaDeFundo from '../../../assets/img/semtitulo.png';
import iconeDeletar from '../../../assets/img/delete-photo.png';
import './dashClassificado.css';
// import { usuarioAutenticado, parseJwt } from '../../../services/auth';	



class DashboardClassificado extends Component{

    constructor(props){
        super(props);
        this.state =  {
            intclassificado: []
                    }
                        
            this.buscarClassificadosInteresse = this.buscarClassificadosInteresse.bind(this)
            this.redirecionarClassificado = this.redirecionarClassificado.bind(this)
                        }
    
    redirecionarClassificado(id){
        window.location.href = '/classificadoInteresses?id=' + id
    }

    buscarClassificadosInteresse(){
    fetch('https://localhost:5001/api/classificado/interesse', {
        headers: {
            "Content-Type": "application/json",
            "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin'), 
                 }

                                                        }
        )
        .then(res => res.json())
        .then(data => {
            this.setState({intclassificado : data})
                        })
    .catch((erro) => console.log(erro))
                        };        


    componentDidMount(){
        this.buscarClassificadosInteresse();
    }

    render(){

        return(
    

            <div>
    <body style ={{ 
    backgroundImage: "url(" + temaDeFundo + ")",
    backgroundRepeat: "no-repeat",
    backgroundAttachment: "fixed",
    background: "cover",
    backgroundSize: "100% 100%"}}>
        
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
                <p>Administrador</p>
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
                    <img src={iconeFile} alt="ícone de classificado"/>
                </div>
            </div>
            <div class="icon_menu_lateral_adm">
            <a href="./DashUsuario"><img src={iconeUser} alt="ícone de equipamentos"/></a>
            </div>
            <div class="icon_menu_lateral_adm">
            <a href="./listarEquipamento">    <img src={iconeComp} alt="ícone de classificados"/></a>
            </div>
            <div class="icon_menu_lateral_adm">
            <a href="./listarCategoria">   <img src={iconeCat} alt="ícone de categorias"/></a>
            </div>
            <div class="icon_menu_lateral_adm">
                <img src={iconeLogout} alt="ícone de saída"/>
            </div>
        </nav>

        <section id="conteudo_tela_lateral_direita_adm">
            <div id="cabecalho_corpo_adm">
                <p>Classificados cadastrados</p>
            </div>
            <div id="corpo_conteudo_adm">
                <div id="limitacao_espaco_corpo_conteudo_adm">
                    <table id="tabela_usuarios_adm">
                        <thead>
                            <tr>
                                <th></th>
                                <th></th>
                                <th>
                                    <a href="#">
                                        nome
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        Fora de serviço desde
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        número de série
                                    </a>
                                </th>
                                <th>
                                    <a href="#">
                                        código
                                    </a>
                                </th>
                                <th>
                                    <a href="#">preço</a>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.intclassificado.map( item => {
                                return(
                            <tr key={item.idClassificado}>
                                <td id="td_input_adm">

                                    <form id="form_input_user_adm" action="">
                                        <input type="checkbox" name="" id=""/>
                                    </form>
                                    
                                </td>
                                <td id="td_imagem_adm"></td>
                                <td id="nome_usuario" style={{cursor:"pointer"}} onClick={ () => this.redirecionarClassificado(item.idClassificado)} >{item.idEquipamentoNavigation.nomeEquipamento}</td>
                                <td>{item.fimDeVidaUtil}</td>
                                <td>{item.numeroDeSerie}</td>
                                <td id="numero_compras_user">{item.codigoClassificado}</td>
                                <td>{item.preco}</td>
                                <td id="botao_delete">
                                    <a href="#">
                                        <div id="box_icon_delete_user">
                                            <img id="icon_delete_user" src={iconeDeletar}
                                                alt="icone do botão de deletar um usuário"/>
                                        </div>
                                    </a>
                                </td>
                            </tr>
                                )
                            }
                            )
                        }
                          
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </main>
</body>






            </div>
        )
    }

}






export default DashboardClassificado;