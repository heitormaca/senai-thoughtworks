import React, {Component} from 'react';
import '../assets/css/cadastroConcluido.css';
import imgprancheta from '../assets/img/Prancheta__1_@1x.png';
import imgprincipal from '../assets/img/Protótipo Confirmação de Cadastro.png';
import Login from '../pages/Login';



class ConfirmacaoCadastro extends Component{

    passarPagina(event){
        event.preventDefault();
    }

    

render(){

    return(
        <div>

    <body>

    <main>

    <sec id="posicao-1-sec-ord-confcad">


    <div id="posicao-2-div-ord-titulo-confcad">
        <h1>Cada</h1><h1>stro</h1>              
    </div>
    

    <div id="posicao-2-div-ord-conteudo-flex-confcad">

        <div id="posicao-3-div-ord-tema-esq-confcad"> 
            <img src={imgprincipal}/>
        </div>

        <div id="posicao-3-div-ord-txt-dir-confcad">
            <div id="posicao-4-ord-txt-img-confcad">
                <img src={imgprancheta}/>
            </div>

                <h3>Concluído</h3>
                <hr style={{background: "#AE07FF", color: "#AE07FF", padding: "0.1em", width: "12em", margin: "0 auto"}}/>
                <p style={{fontFamily: "Segoe Ui", margin: "1em 1.5em"}}>Obrigado por se cadastrar em nosso sistema, 
                    estamos contentes em ter você aqui :)</p>
        </div>

    </div>

    <div style={{margin:"0 auto"}} id="posicao-2-div-ord-inf-confcad">
        <p>Agora já podemos começar, vamos lá?</p> 
        
       <a href="/Apresentacao"> <button id="posicao-3-btn-ord-inf-inf-confcad"> Começar</button></a>
    </div>
</sec>


</main>

</body>


        </div>
    )
}
}

export default ConfirmacaoCadastro;