export const usuarioAutenticado = () => localStorage.getItem('usuario-token') !== null;

export const parseJwt = () => {
    if(localStorage.getItem('usuario-token') != null){
        let base64 = localStorage.getItem('usuario-token').split('.')[1];

        return JSON.parse(window.atob(base64))
    }
    else{
        return null
    }
};