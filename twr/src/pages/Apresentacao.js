import React, {Component} from 'react';
import '../assets/css/apresentacao.css';
import img1 from '../assets/img/logo-nt-invertido.png';
import img2 from '../assets/img/blogpost-banner.png';
import img3 from '../assets/img/banner_image.png';



class Aprensatacao extends Component{

    render(){
        return(
    
    <div>
    <body>

    <header id="topo-apresentacao"> 
        <nav class="menu-apresentacao">
            <a href="/">
                <img class="imagem_logo_apresentacao" src={img1} alt="logo do site new time em tons azulado"/>
                <h1 id="apresentacao-logo">NewTime Logo</h1> 
            </a>
            <ul id="ul-apresentacao"> 
                <a href="/"> <button class="button-apresentacao-nt"><span>Entrar</span></button></a> 
            </ul>
        </nav> 
    </header> 
    
    
    <main class="apresentacao-banner"> 
        <section id="banner-apresentacao">
            <div class="divisoria-imagem-apresentacao">
                <img class="imagem-banner-apresentacao" src={img2} alt="desenho de um homem comprando virtualmente"/>
            </div>
        </section>
    </main> 
    
    
    
    <section id="primeira-section-apresentacao"> 
        <div class="itens-apresentacao-um"> 
            <h2 class="hdois-um-apresentacao">É realmente uma boa?</h2>
            <hr class="hr-um-apresentacao"/> 
            <p class="paragrafo-um-apresentacao">Manter equipamentos que não estão mais nas melhores condições de funcionamento pode significar queda de
                produtividade dos funcionários e certamente representa perda de dinheiro para a companhia.
                Em um segundo momento, a empresa iniciou um processo de vendas para os funcionários, baseado no preço de mercado de PCs e notebooks usados com um desconto adicional
                de 25%. As máquinas são formatadas e entregues limpas, sem software que exigem licenças.
                Já que não é possível faturar financeiramente com a substituição de ativos, muitas empresas optam por trocar suas máquinas mais antigas por uma moeda menos tangível.</p>
            </div> 
        </section> 
        
        <section id="segunda-section-apresentacao"> 
            <div class="itens-apresentacao-dois"> 
                <h2 class="hdois-dois-apresentacao">Legal, como funciona?</h2> 
                <hr class="hr-dois-apresentacao"/>
                <p class="paragrafo-dois-apresentacao">Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum, alias deleniti reiciendis 
                    magni expedita repudiandae repellendus doloremque nobis sequi nostrum iusto consequatur quibusdam sint quis aut sunt nesciunt
                    esse voluptatum.Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum, alias deleniti reiciendis magni expedita 
                    repudiandae repellendus doloremque nobis sequi nostrum iusto consequatur quibusdam sint quis aut sunt nesciunt esse voluptatum.</p>
                    <div class="imagem-de-apresentacao-segunda-section">
                        <img class="imagem-segunda-section-apresentacao" src={img3} alt="desenho de um homem usando uma camisa verde com dúvidas"/> 
                    </div>
                </div> 
            </section> 
            
            
            <footer class="footer-apresentacao">
                <div class="imagem-footer-apresentacao"> 
                    </div>
                
                <div class="lista-opcoes-footer-apresentacao">
                    <ol id="olis-footer-apresentacao"> 

                      
                        <a href="#"><li class="li-footer-apresentacao"> Imprensa e Mídia </li> </a>  
                        <a href="#"><li class="li-footer-apresentacao"> Saiba Mais </li></a>
                         <a href="#"><li class="li-footer-apresentacao"> Política de privacidade </li></a> 
                    </ol> 
                </div>
                <div class="lista-icones-footer-apresentacao"> 
                    </div>
                </footer>
            </body>
            </div>
        )
    }

}

export default Aprensatacao;