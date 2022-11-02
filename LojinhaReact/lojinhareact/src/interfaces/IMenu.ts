import IBaseInterface from "./IBaseInterface";

export default interface IMenu extends IBaseInterface{
    nome: string;
    caminho: string;
    icone: string;
    categoriaAcessoId: number;
    
}