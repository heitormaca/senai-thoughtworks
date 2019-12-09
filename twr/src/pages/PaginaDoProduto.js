import React, {Component} from 'react';
import '../assets/css/PaginaDoProduto.css'
import prdtt from '../assets/img/macbook.png'
import Rodape from '../componentes/Rodape';



class PaginaDoProduto extends Component{

    render(){
        return(

            
            <body>

        <main className="conteudo">
       <section className="produto_conteudo">
           <div className="produto_conteudo_center">
               <div className="box1">
                   <img src={prdtt} />
                   <ul>
                       <li></li>
                       <li></li>
                       <li></li>
                       <li></li>
                   </ul>
               </div>
               <div className="box2">
                   <div className="box2_cap">
                       <h1 className="box2_cap_titulo">MacBook MLHF2BZ/A Mac OS X El captain...</h1>
                       <h4 className="box2_cap_cod">Cod.47856749</h4>
                           <h2 className="box2_cap_preco">R$7.000,00</h2>
                           <button className="box2_cap_button">Registrar interesse</button>
                   </div>
               </div>
           </div>
       </section>
       <section className="produto_desc_info">
           <div className="produto_desc">
               <h3>Informações do produto</h3>
               <div className="produto_desc2">
                   <h4> MacBook Pro genial em cada toque.</h4>

                   <p> Ultrafino, superleve e ainda mais rápido e poderoso. O MacBook Pro é tudo isso e muito mais. Ele
                       tem a tela mais brilhante e colorida em um notebook Mac.
                       O MacBook Pro é o resultado de ideias inovadoras e está pronto para receber as suas.
                   </p>
                   <h4>Bateria</h4>
                   <p> MacBook Pro oferece desempenho ainda maior em um design mais fino. E, mesmo assim, a bateria
                       dura o dia inteiro: até 10 horas para os modelos de
                       13 polegadas e 15 polegadas1. Ou seja, você tem a liberdade de assistir, jogar e editar de onde
                       estiver.
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
                           <td className="colunafake" colspan="3">1123123</td>
                       </tr>
                       <tr>
                           <td className="subt" colspan="3">Marca</td>
                           <td className="colunafake" colspan="3">1123123</td>
                       </tr>
                       <tr>
                           <td className="subt" colspan="3">Modelo</td>
                           <td className="colunafake" colspan="3">1123123</td>
                       </tr>
                       
                           <tr>
                               <td className="subt" colspan="3">Sistema Operacional</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Polegada da Tela</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Processador</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Memoria RAM</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">SDD</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">HD</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Placa de video</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>
                           <tr>
                               <td className="subt" colspan="3">Código</td>
                               <td className="colunafake" colspan="3">1123123</td>
                           </tr>

                   </table>
               </div>
           </div>
       </section>
   </main>
    <Rodape/>
</body>


            )
        }
}

export default PaginaDoProduto;