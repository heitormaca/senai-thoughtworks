import React, {Component} from 'react';
import './PaginaDoProduto.css'
import prdtt from '../../../assets/img/macbook.png'



class PaginaDoProduto extends Component{
    constructor(props){
        super(props)
        this.state = {
            idClassificado: '',
            classificado: []
        }
        this.removerIdDaUrl = this.removerIdDaUrl.bind(this)
        this.buscarClassificadoPorId = this.buscarClassificadoPorId.bind(this)
    }

    async componentDidMount(){
        await this.removerIdDaUrl()
        this.buscarClassificadoPorId()
    }

    removerIdDaUrl(){
        var url = window.location.href
        var id = url.split('=')[1]
        this.setState({ idClassificado : id})
    }

    buscarClassificadoPorId(){
        fetch('https://localhost:5001/api/classificado/' + this.state.idClassificado, {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
            }
        })
        .then(resposta => resposta.json())  
        .then(data => {this.setState({classificado : data})

        this.setState({nomeEquipamento : data.idEquipamentoNavigation.nomeEquipamento})
        this.setState({marca : data.idEquipamentoNavigation.marca})
        this.setState({modelo : data.idEquipamentoNavigation.modelo})
        this.setState({sistemaOperacional : data.idEquipamentoNavigation.sistemaOperacional})
        this.setState({processador : data.idEquipamentoNavigation.processador})
        this.setState({memoriaRam : data.idEquipamentoNavigation.memoriaRam})
        this.setState({ssd : data.idEquipamentoNavigation.ssd})
        this.setState({hd : data.idEquipamentoNavigation.hd})
        this.setState({placaDeVideo : data.idEquipamentoNavigation.placaDeVideo})
        this.setState({alimentacao : data.idEquipamentoNavigation.alimentacao})
        this.setState({peso : data.idEquipamentoNavigation.peso})
        this.setState({dimensoes : data.idEquipamentoNavigation.dimensoes})
        this.setState({polegada : data.idEquipamentoNavigation.polegada})
        // this.setState({nomeCategoria : data.idCategoria.nomeCategoria})


        

        



        ;console.log(this.state.classificado.idEquipamentoNavigation.nomeEquipamento)}
             ).catch((erro) => console.log(erro))
    }


    render(){
        return(

            
            <body>

        <main style={{height:"120em"}} className="conteudo">
       <section className="produto_conteudo">
           <div className="produto_conteudo_center">
               <div className="box1">
                   <img src={prdtt} />
               </div>

               <div className="box2">
                   <div className="box2_cap">
                       <h1 className="box2_cap_titulo">{this.state.nomeEquipamento}</h1>
                       <h4 className="box2_cap_cod"> Código: {this.state.classificado.codigoClassificado}</h4>
                           <h2 className="box2_cap_preco">Por: R$ {this.state.classificado.preco}</h2>
                           <button className="box2_cap_button" style={{ cursor: 'pointer' }}
                           onClick={() => {
                            console.log(this.state.idClassificado)
                            fetch('https://localhost:5001/api/interesse', {
                                method: 'POST',
                                body: JSON.stringify({ idClassificado: this.state.idClassificado }),
                                headers: {
                                    'Content-type': 'application/json',
                                    'authorization': 'Bearer ' + localStorage.getItem('autenticarlogin')
                                }
                            })
                                .then(resposta => {
                                    if (resposta.status === 200) {
                                        console.log('Cadastro de interesse concluído com sucesso')
                                    }
                                    else {
                                        console.log(JSON.stringify({ idClassificado: this.state.idClassificado }))
                                    }
                                })
                        }}
                           
                           >Registrar interesse</button>
                   </div>
               </div>

           </div>
       </section>
       <section className="produto_desc_info">
           <div className="produto_desc">
               <h3>Informações do produto</h3>
               <div className="produto_desc2" style={{height:"20em", marginBottom:"3em"}}  >
                   <h4 style={{marginBottom:"2em"}}> {this.state.nomeEquipamento} </h4>

                   <p style={{color:"darkblue"}}> Sistema operacional </p> {this.state.sistemaOperacional}
                    <h4 style={{margin:"1em 0em"}}> Avaliação do estado do produto:</h4>
                   <p style={{ margin:"1em 0em", color:"red"}}> 
                     {this.state.classificado.avaliacao} 
                   </p>

                   <h4>Imagens meramente ilustrativas.</h4>
                   <p>
                       Todas as informações divulgadas são de responsabilidade do Fabricante/Fornecedor.
                       Verifique com os fabricantes do produto e de seus componentes eventuais limitações à utilização
                       de todos os recursos e funcionalidades.
                   </p>

               </div>
           </div>
       </section>
       <section className="produto_ficha_info">
           <div className="produto_ficha">
               <h3>Ficha técnica</h3>
               <div className="produto_ficha2">
                   <table className="tabelas">
                       <caption>TITULO</caption>
                       <tr>
                           <td className="subt" colspan="3">Código</td>
                           <td className="colunafake" colspan="3">{this.state.classificado.codigoClassificado}</td>
                       </tr>
                       <tr>
                           <td className="subt" colspan="3">Marca</td>
                           <td className="colunafake" colspan="3">{this.state.marca}</td>
                       </tr>
                       <tr>
                           <td className="subt" colspan="3">Modelo</td>
                           <td className="colunafake" colspan="3"> {this.state.modelo} </td>
                       </tr>
                           <tr>
                               <td className="subt" colspan="3">Sistema Operacional</td>
                               <td className="colunafake" colspan="3"> {this.state.sistemaOperacional} </td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Polegada da Tela</td>
                               <td className="colunafake" colspan="3"> {this.state.polegada} </td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Processador</td>
                               <td className="colunafake" colspan="3"> {this.state.processador} </td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Memoria RAM</td>
                               <td className="colunafake" colspan="3"> {this.state.memoriaRam} </td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">SDD</td>
                               <td className="colunafake" colspan="3">{this.state.ssd}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">HD</td>
                               <td className="colunafake" colspan="3">{this.state.hd}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Softwares inclusos</td>
                               <td className="colunafake" colspan="3">{this.state.classificado.softwaresInclusos}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Placa de video</td>
                               <td className="colunafake" colspan="3">{this.state.placaDeVideo}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Dimensoes</td>
                               <td className="colunafake" colspan="3">{this.state.dimensoes}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">{this.state.ssd}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Data de fabricação</td>
                               <td className="colunafake" colspan="3">{this.state.classificado.dataFabricacao}</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Fora de serviço desde</td>
                               <td className="colunafake" colspan="3">{this.state.classificado.fimDeVidaUtil}</td>
                           </tr>

                   </table>
               </div>
           </div>
       </section>
   </main>
</body>


            )
        }
}

export default PaginaDoProduto;