import React, {Component} from 'react';
import './historico.css';
import prdt from '../../assets/img/download_-1.png';
import Rodape from '../../componentes/rodape/Rodape';
import Cabecalho from '../../componentes/cabecalho/Cabecalho';


class Historico extends Component{

    constructor(props){
        super(props);
        this.state = {
            listInteresse: [],
            loading : false 
        }
        this.buscarInteresse = this.buscarInteresse.bind(this);
    }

    componentDidMount(){
        this.buscarInteresse()
    }

    buscarInteresse(){
        fetch('https://localhost:5001/api/interesse/listInteresses', {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                     }
        }).then(resposta => resposta.json())
        .then(data => {this.setState({listInteresse : data})
        this.setState({loading : false});
        }).catch((erro) => console.log(erro))
    }


    render(){
        return(

<div>
<body style={{backgroundImage:"none"}}>
    <Cabecalho/>
<main id="dif1234">
<sec id="posicao-1-ord-sec-hist">
            <div id="posicao-2-ord-div-hist">
                <table id="posicao-3-ord-tab-hist" style={{width:"100%", height:"7rem"} }>
                    <tbody>
                    
                        <tr>
                            <td style= {{ backgroundColor: "white", marginBottom: "1.5em",     marginTop: "1.5em",
                         width: "100%", height: "1.5rem", display: "flex", justifyContent:"center", flexDirection:"column", color: "##005DFF", fontweight: "400", boxshadow: "none"}}>
                             <h3 style= {{fontSize:"1.6em", textTransform:"uppercase", color: "#00205A"}} >Interesses</h3>
                            <hr style={{background: "#00205A", color: "#AE07FF", padding: "0.1em", width: "12em", margin: "0 auto"}}/>

                            </td>
                        </tr>

                       <tr>
                           <td
                           style= {{ backgroundColor: "white", marginbottom: "1.18rem",     margintop: "1.2rem",
                           width: "100%", height: "1.5rem", display: "flex", justifyContent:"flex-end", color: "gray", fontweight: "400", boxshadow: "none"}}>
                        <h3></h3></td>
                        
                       </tr>

                {this.state.listInteresse.map(item => {
                return(
                     <tr key={item.idInteresse}>
                            <td> <img src={prdt}/>
                            <div className="posicao-5-ord-par-hist">
                                <p style={{color:"black"}}>{item.idClassificadoNavigation.idEquipamentoNavigation.nomeEquipamento} {item.idClassificadoNavigation.idEquipamentoNavigation.marca}  
                                  {item.idClassificadoNavigation.idEquipamentoNavigation.processador} {item.idClassificadoNavigation.idEquipamentoNavigation.placaDeVideo} 
                                
                                 </p>
                            </div>
                                <div className="posicao-inf-ord-div-hist">
                                    <h3>R$ {item.idClassificadoNavigation.preco}</h3>
                                </div>
                            </td>
                            <br/>
                        </tr>
                        )})}


                    </tbody>
                </table>

            </div>

        </sec>
    </main>
    <Rodape/>
            
            </body>

            </div>
        )
    }

}

export default Historico;