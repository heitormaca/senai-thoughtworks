import React from 'react';
import './App.css';
import img from './assets/img/macbook.png';
import pd1 from './assets/img/buffer.png';
import pd2 from './assets/img/laptop.png';
import pd3 from './assets/img/dollar-symbol.png';
import Cabecalho from './componentes/Cabecalho';



function App() {
  
  return (
    
    <div>

      <Cabecalho/>

    <body>
  
  <section className="banner-home">
    <div className="imagem-banner-home">              </div>
  </section>
  
  
  <section className="home_filtro">
    <div className="home_filtro_box_bottom_box1_box">
      <div className="home_filtro_box_bottom_box1_box_1">
        <div className="home-circulo-filtro-um">
          <img src={pd1}/>
        </div>
        <a href="" className="linkagem-filtro-home"><p className="paragrafo-filtro-home">Ordenar por categoria</p></a>
        <i className="fas fa-chevron-down" className="icone-flecha"></i>
      </div>
      <div className="barra-serapacao-filtro"></div>
      
      <div className="home_filtro_box_bottom_box1_box_1">
        <div className="home-circulo-filtro-dois">
          <img src={pd2} />
        </div>
        <a href="" className="linkagem-filtro-home"><p className="paragrafo-filtro-home">Ordenar por marca</p></a>
        <i className="fas fa-chevron-down" className="icone-flecha"></i>
      </div>
      <div className="barra-serapacao-filtro"></div>
      
      <div className="home_filtro_box_bottom_box1_box_1">
        <div className="home-circulo-filtro-tres">
          <img src={pd3}/>
        </div>
        <a href="" className="linkagem-filtro-home"><p className="paragrafo-filtro-home">Ordenar por preço</p></a>
        <i className="fas fa-chevron-down" className="icone-flecha"></i>
      </div>
    </div>
  </section>
  

  
  <main>
    <section className="home-inicio-apresentacao">
      <div className="home-notebook-apresentacao">
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                <img src={img}/>

                </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section className="home-inicio-apresentacao">
      <div className="home-notebook-apresentacao">
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        {/* <i className="fas fa-shopping-cart"></i> */}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section className="home-inicio-apresentacao">
      <div className="home-notebook-apresentacao">
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        {/* <i className="fas fa-shopping-cart"></i> */}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="home-notebook-box">
          <div className="home-cards-separacao-notebooks">
            <div className="home_produto_desk_box_box_card">
              <div className="home-guardar-notebooks">
                {/* <img src="assets/images/macbook.png" alt="Imagem do produto MacbookPro"> */}
              </div>
              <div className="home_produto_desk_box_box_card_bottom">
                <div className="home-descricao-notebooks">
                  <p>Notebook Apple Macbook Air</p> 
                  <p>Mqd32ll/ A I5-1.8/ 8/ 128/ 13</p>
                </div>
                <div className="home-carrinhos-cards">
                  <div className="home-precos-cards-left">
                    <div className="home-precos-cards-bottom">
                      <div className="home-borda-preco-notebooks">
                        <p>R$ 10.000,00</p>
                      </div>
                    </div>
                  </div>
                  <div className="home-cards-configuracao-carrinhos">
                    <div className="home-produto-interesse-notebook">
                      <div className="home-carrinhos-box">
                        <i className="fas fa-shopping-cart"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </main>

</body>


    </div>

  )
}

export default App;