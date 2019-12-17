import React, {Component} from 'react';



class DashboardListarCategoria extends Component{

    constructor(props){
        super(props);
        this.state = {
            listarCat: [],
            nomeCategoria: '',
            loading : false 
        }
        this.buscarCategoria.bind(this);
    }


    buscarCategoria(){
        fetch('https://localhost:5001/api/Categoria', {
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                     }
        }).then(resposta => resposta.json())
        .then(data => {this.setState({listarCat : data})
        this.setState({loading : false});
    }).catch((erro) => console.log(erro))
    }

    componentDidMount(){
        this.buscarCategoria();
    }


render(){
            return(
    
                <div>
    
                    <div>
                        {this.state.listarCat.map(function(Categoria){
                            return(
                       <table>
                           <th>Categorias</th>
                           <tr key={Categoria.idCategoria}>
                               <td>{Categoria.nomeCategoria}</td>
                           </tr>
                       </table>
                   

                    )    
                    }
                    )
                    }
                    </div>
                </div>
                
    
    
            )
        }
    }

    export default DashboardListarCategoria;