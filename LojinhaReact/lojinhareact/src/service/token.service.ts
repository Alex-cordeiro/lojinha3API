export const tokenKey = '@token';

export const getToken = () => localStorage.getItem(tokenKey);

export const setToken = (token:string) => localStorage.setItem(tokenKey, token);

export const cleanLocalStorage = () => {
    
    localStorage.clear();
    window.location.reload();
}