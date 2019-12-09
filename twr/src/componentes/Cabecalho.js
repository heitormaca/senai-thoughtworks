import React from 'react';
import '../assets/css/Cabecalho.css';
import img1 from '../assets/img/logo-nt.png';
import img2 from '../assets/img/heitor.png';



function Cabecalho(){
    return(
        
    
    <header class="cabecalho">
        <nav class="nav_menu">
            <div class="nav_menu_img">
                <a href="/"><img src={img1} alt=""/></a>
            </div>

            <form action="#" method="GET">
                <input type="text" name="search" placeholder="Buscar..."/>
                <i class="fas fa-search" aria-hidden="true"></i>
            </form>
            <div class="nav_menu_items">
                <ul>
                    <li><a href="/Historico">Interesses</a></li>
                    <li><a href="/Historico de compras">Compras</a></li>
                    <li><a>Sobre</a></li>
                </ul>
            </div>
            <div class="nav_menu_img">
                <img src={img2} alt=""/>
            </div>
            <div class="nav_menu_botao">
                    <i class="fas fa-bars"></i>
                </div>

        </nav>
    </header>


    );
}

export default Cabecalho;