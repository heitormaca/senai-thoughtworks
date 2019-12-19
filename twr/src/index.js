import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import { usuarioAutenticado, parseJwt } from './services/auth';

// páginas 
import cadastro from './pages/usuario/cadastro/Cadastro'
import cadastroConcluido from './pages/usuario/cadastroConfirmado/ConfirmacaoCadastro'
import apresentacao from './pages/usuario/apresentacao/Apresentacao'
import login from './pages/usuario/login/Login'
import home from './pages/usuario/home/Home'
import produto from './pages/usuario/paginaDoProduto/PaginaDoProduto'
import perfil from './pages/usuario/perfilUser/Perfil'
import historicoInteresse from './pages/usuario/historicoDeInteresse/Historico'
import historicoCompras from './pages/usuario/historicoDeCompras/HistoricoCompras'
import listarUser from './pages/administrador/listarUsuario/DashboardUsuario'
import listarCategoria from './pages/administrador/listarCategoria/DashboardListarCategoria'
import cadastrarCategoria from './pages/administrador/cadastrarCategoria/DashboardCadastrarCategoria'
import listarEquipamentoClassificado from './pages/administrador/listarEquipamentoCadastro/listarEquipamentoClassificado'
import cadastrarEquipamento from './pages/administrador/cadastrarEquipamento/cadastroEquipamento'
import listarClassificado from './pages/administrador/listarClassificado/DashboardClassificados'
import cadastrarClassificado from './pages/administrador/cadastrarClassificado/DashboardCadastrarClassificado'
import listarClassificadoInteresses from './pages/administrador/listarInteresses/listarInteresses'

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
                <Route path='/home' component={home}/> 
                <ContriAuth exact path ='/' component={apresentacao}/>
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
                <AdminAuth path='/listarEquipamentoClassificado' component={listarEquipamentoClassificado} />
                <AdminAuth path='/listarClassificado' component={listarClassificado} />
                <AdminAuth path='/classificadoInteresses' component={listarClassificadoInteresses} />
                
            </Switch>

        </div>
    </Router>
)
ReactDOM.render(Rota, document.getElementById('root'));

serviceWorker.unregister();