import React from 'react';
import '../barraLateralADM/BarraLateralADM.css'
import img from '../../assets/img/user.png'
import img1 from '../../assets/img/laptop.png'
import img2 from '../../assets/img/file.png'
import img3 from '../../assets/img/categorias.png'
import img4 from '../../assets/img/shopping-cart.png'
import img5 from '../../assets/img/logout.png'

function BarraLateralADM(){
    return(
        <div>
            <nav id="menu_lateral_esquerda_adm-10">
                <div class="identificador_menu_lateral_adm-10">
                    <div class="identificador_menu_lateral_cor_adm-10"></div>
                    <a href="#">
                        <div class="icon_menu_lateral_adm-10">
                            <img src={img} alt="ícone de usuário"></img>
                        </div>
                    </a>
                </div>
                <a href="#">
                    <div class="icon_menu_lateral_adm-10">
                        <img src={img1} alt="ícone de equipamentos"></img>
                    </div>
                </a>
                <a href="#">
                    <div class="icon_menu_lateral_adm-10">
                        <img src={img2} alt="ícone de classificados"></img>                    </div>
                </a>
                <a href="#">
                    <div class="icon_menu_lateral_adm-10">
                        <img src={img3} alt="ícone de categorias"></img>
                    </div>
                </a>
                <a href="#">
                    <div class=
                "icon_menu_lateral_adm-10">
                        <img src="../assets/img/shopping-cart.png" alt="icone de classificados com interesses">
                    </div>
                </a>
                <a href="#">
                    <div class="icon_menu_lateral_adm-10">
                        <img src="../assets/img/logout.png" alt="ícone de saída">
                    </div>
                </a>
            </nav>
        </div>
    );
}
export default BarraLateralADM;