import React, {Component} from 'react';
import '../assets/css/historico.css';
import prdt from '../assets/img/download_-1.png';
import Rodape from '../componentes/Rodape';
import Cabecalho from '../componentes/Cabecalho';


class Historico extends Component{

    render(){
        return(

<div>
<body>
    <Cabecalho/>
<main>
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
                         <h3>26/11/2019</h3></td>
                       </tr>
                         
                     <tr>
                            <td> <img src={prdt}/>
                            <div className="posicao-5-ord-par-hist">
                                <p style={{color:"black"}}>MacBook MF855BZ/A Intel Core M Dual Core 12 8GB 256GB Prata - Apple</p>
                            </div>
                                <div className="posicao-inf-ord-div-hist">
                                    <h3>R$ 10.000</h3>
                                </div>
                            </td>
                        </tr>


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