import React, {Component} from 'react';
import '../assets/css/dashuser.css';
import iconeUser from '../assets/img/user.png';
import iconeLaptop from '../assets/img/laptop.png';
import iconeFile from '../assets/img/file.png';
import iconeCat from '../assets/img/categorias.png';
import iconeLogout from '../assets/img/logout.png';
import temaDeFundo from '../assets/img/semtitulo.png';



class DashBoardUsuario extends Component{

    constructor(props){
        super(props);
        this.state = {
            listarUsr : [],
            nomeCompleto : '',
            email : '',
            nome : '',
            loading : false, 
        }
        this.buscarUsuarios.bind(this);
        // this.atualizaNome = this.atualizaNome.bind(this);
        // this.atualizaNomeCompleto = this.atualizaNomeCompleto.bind(this);
        // this.atualizaEmail = this.atualizaEmail.bind(this)
    }





    buscarUsuarios(){

        this.setState({loading : true});

        fetch('https://localhost:5001/api/Usuario')
        .then(resposta => resposta.json())
        .then(data => {
        this.setState({ listarUsr : data})
        
        // setar state do loading não aparecer
        this.setState({loading : false});

        })
        .catch((erro) => console.log(erro)) 
        }

    componentDidMount(){
        this.buscarUsuarios();
    }








    render(){
        return(
            <div>
    <body style ={{ 
    backgroundImage: "url(" + temaDeFundo + ")",
    backgroundRepeat: "no-repeat",
    backgroundAttachment: "fixed",
    background: "cover",
    backgroundSize: "100%, 100%"}}>
        
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
                    <img src={iconeUser}/>
                </div>
            </div>
            <div class="icon_menu_lateral_adm">
            <img src={iconeLaptop}/>

            </div>
            <div class="icon_menu_lateral_adm">
            <img src={iconeFile}/>

            </div>
            <div class="icon_menu_lateral_adm">
            <img src={iconeCat}/>

            </div>
            <div class="icon_menu_lateral_adm">
            <img src={iconeLogout}/>

            </div>
        </nav>

        <section id="conteudo_tela_lateral_direita_adm" style={{ 
            backgroundImage: "url(" + temaDeFundo + ")",
         }}>
            <div id="cabecalho_corpo_adm" style={{
         backgroundImage: "url(" + temaDeFundo + ")",
            }}>
                <p>Usuários</p>
            </div>
            <div id="corpo_conteudo_adm">
                <div id="limitacao_espaco_corpo_conteudo_adm">
                    <table id="tabela_usuarios_adm">
                   
                        <tr>
                            <th></th>
                            <th></th>
                            <th>
                                <a href="#">
                                    nome de usuário
                                </a>
                            </th>
                            <th>
                                <a href="#">
                                    nome completo
                                </a>
                            </th>
                            <th>
                                <a href="#">
                                    email
                                </a>
                            </th>
                            <th>
                                <a href="#">
                                    compras
                                </a>
                            </th>
                        </tr>

                       





                        {this.state.listarUsr.map(function(Usuario){
                        
                        return( 
                            
                            <tr key={Usuario.IdUsuario}>
                            <td id="td_input_adm">
                                <form id="form_input_user_adm" action="">
                                    <input type="checkbox" name="" id=""/>
                                </form>
                                
                            </td>
                            <td id="td_imagem_adm">
                            </td>
                            <td id="nome_usuario">{Usuario.nomeUsuario}</td>
                            <td>{Usuario.nomeCompleto}</td>
                            <td>{Usuario.email}</td>
                            <td id="numero_compras_user">{Usuario.idUsuario}</td>
                            <td id="botao_delete">
                                <a href="#">
                                    <div id="box_icon_delete_user">
                                        {/* <img id="icon_delete_user" src="../assets/img/delete-photo.png" alt="icone do botão de deletar um usuário"> */}
                                    </div>
                                </a>
                            </td>
                          
                        </tr>
                            )})}
                        <tr id="borda_tabela_user_box_adm">
                            <th></th>
                        </tr>
                        
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

export default DashBoardUsuario;