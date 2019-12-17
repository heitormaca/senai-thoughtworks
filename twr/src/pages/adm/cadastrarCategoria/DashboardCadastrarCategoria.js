import React, {Component} from 'react';



class DashboardCadastrarCategoria extends Component{

    constructor(props){
        super(props);
        this.state = {
            nomeCategoria: ''
        }

    this.cadastrarCategoria = this.cadastrarCategoria.bind(this);
    this.atualizaEstadoNomeCategoria = this.atualizaEstadoNomeCategoria.bind(this);

    }

    atualizaEstadoNomeCategoria(event){
        this.setState({nomeCategoria:event.target.value})
    }

    cadastrarCategoria(event){
        event.preventDefault();
        fetch('https://localhost:5001/api/Categoria', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Authorization": 'Bearer ' + localStorage.getItem('autenticarlogin')
                     },
            body: JSON.stringify({
                nomeCategoria : this.state.nomeCategoria
            }),
            headers: {'Content-type': 'application/json'}
        })
    }


    render(){
            return(
    
                <div>
    
                    <div>
                        <form onSubmit={this.cadastrarCategoria}>
                    <input value={this.state.nomeCategoria} onChange={this.atualizaEstadoNomeCategoria} placeholder="Nome da categoria"/>
                    <button type="submit" onClick="cadastrarCategoria()">Cadastrar</button>
                        </form>
                    </div>
                </div>
                
    
    
                 )
            }
                                    }

    export default DashboardCadastrarCategoria;