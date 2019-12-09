import React from 'react';
import '../assets/css/Rodape.css';
import img1 from '../assets/img/social-facebook-circular-button (-1.png';
import img2 from '../assets/img/social-linkedin-circular-button (-1.png';
import img3 from '../assets/img/social-google-plus-circular-button.png';
import twimg from '../assets/img/tw.png';


function Rodape(){
    return(

        <footer class="rodape">
        <div class="rodape_structure">
            <div class="rodape_structure_img">
                <img src={twimg}/>
            </div>
            <nav class="rodape_structure_nav">
                <ul>
                    <li><a href="#">Interesses</a></li>
                    <li><a href="#">Compras</a></li>
                    <li><a href="#">Sobre</a></li>
                </ul>
            </nav>
            <div class="rodape_structure_icons">
                <img src={img1}/>
                <img src={img2}/>
                <img src={img3}/>
            </div>
        </div>
        <nav class="rodape_structure_nav_mobile">
            <ul>
                <li><a href="#">Interesses</a></li>
                <li><a href="#">Compras</a></li>
                <li><a href="#">Sobre</a></li>
            </ul>
        </nav>
        <div class="rodape_structure_icons_mobile">
            <img src={img1}/>
            <img src={img2}/>
            <img src={img3}/>
        </div>
    </footer>

    );
}

export default Rodape;