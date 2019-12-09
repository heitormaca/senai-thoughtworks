export const usuarioAutenticado = () => localStorage.getItem('autenticar') !== null;

export const parseJwt = () => {
    var base64 = localStorage.getItem('autenticar').split('.')[1];
    return JSON.parse(window.atob(base64));
}