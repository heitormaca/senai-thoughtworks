export const usuarioAutenticado = () => localStorage.getItem('autenticarlogin') !== null;

export const parseJwt = () => {
    var base64 = localStorage.getItem('autenticarlogin').split('.')[1];
    return JSON.parse(window.atob(base64));
}



