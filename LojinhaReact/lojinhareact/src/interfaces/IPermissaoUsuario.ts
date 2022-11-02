import IBaseInterface from "./IBaseInterface";
import IMenu from "./IMenu";

export interface IPermissaoUsuario extends IBaseInterface{
    menu: IMenu;
}