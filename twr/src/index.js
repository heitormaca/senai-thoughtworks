import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import { usuarioAutenticado, parseJwt } from './services/auth';

// páginas 
import cadastro from './pages/cadastro/Cadastro'
import cadastroConcluido from './pages/cadastroConfirmado/ConfirmacaoCadastro'
import apresentacao from './pages/apresentacao/Apresentacao'
import login from './pages/login/Login'
import home from './pages/home/Home'
import produto from './pages/paginaDoProduto/PaginaDoProduto'
import perfil from './pages/perfilUser/Perfil'
import historicoInteresse from './pages/historicoDeInteresse/Historico'
import historicoCompras from './pages/historicoDeCompras/HistoricoCompras'
// páginas adm
import listarUser from './pages/adm/listarUsuario/DashboardUsuario'
import listarCategoria from './pages/adm/listarCategoria/DashboardListarCategoria'
import cadastrarCategoria from './pages/adm/cadastrarCategoria/DashboardCadastrarCategoria'
import listarEquipamento from './pages/adm/listarEquipamento/listarEquipamento'
import cadastrarEquipamento from './pages/adm/cadastrarEquipamento/cadastroEquipamento'
import listarClassificado from './pages/adm/listarClassificado/DashboardClassificados'
import cadastrarClassificado from './pages/adm/cadastrarClassificado/DashboardCadastrarClassificado'
import listarClassificadoInteresses from './pages/adm/listarInteresses/listarInteresses'





const AdminAuth = ({ component : Component }) => (
    <Route
    render = {
        props => usuarioAutenticado() 
        && parseJwt().Role === 'Administrador' ? ( 
    < Component {...props} /> ) : ( <Redirect to = {{ pathname : 'login' }}/> )
}
/>
)

const ContriAuth = ({ component : Component }) => (
    <Route
    render = {
        props => usuarioAutenticado() 
        && parseJwt().Role === 'Comum' ? ( 
    < Component {...props} /> ) : ( <Redirect to = {{ pathname : 'login' }}/> )
}
/>
)



const Rota = (
    <Router>
        <div>
            
            <Switch>

                                {/* páginas de usuario */}
                <Route path='/Cadastro' component={cadastro}/>  
                <Route path='/Bem vindo' component={cadastroConcluido} />               
                <Route path='/Login' component={login} />
                <Route path='/Apresentacao' component={apresentacao}/> 
                <ContriAuth exact path ='/' component={home}/>
                <ContriAuth path='/Historico' component= {historicoInteresse}/>
                <ContriAuth path='/Historico de compras' component={historicoCompras}/>
                <ContriAuth path='/Perfil' component={perfil}/>    
                <ContriAuth path='/Produto' component={produto}/>  
                      
                                {/* páginas de adm  */}
                <AdminAuth path='/DashUsuario' component={listarUser} />
                <AdminAuth path='/cadastrarCategoria' component={cadastrarCategoria} />
                <AdminAuth path='/cadastrarEquipamento' component={cadastrarEquipamento} />
                <AdminAuth path='/cadastrarClassificado' component={cadastrarClassificado} />
                <AdminAuth path='/listarCategoria' component={listarCategoria} />
                <AdminAuth path='/listarEquipamento' component={listarEquipamento} />
                <AdminAuth path='/listarClassificado' component={listarClassificado} />
                <AdminAuth path='/classificadoInteresses' component={listarClassificadoInteresses} />
                
            </Switch>

        </div>
    </Router>
)

ReactDOM.render(Rota, document.getElementById('root'));

serviceWorker.unregister();