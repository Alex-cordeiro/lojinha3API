import { useEffect, useState } from "react";
import api from "../../../Core/api/api";

interface PermissaoUsuario{
    createdAt: Date,
    descricao: string,
    icone: string,
    id: number,
    nome: string,
}


export function useCategoria(){

    const [categorias, setCategorias] = useState<Categoria[]>();
    async function retornaCategorias(){
        const {data} = await api.get("/CategoriaMenuAcesso/RetornaCategoriasMenuAcesso");
        setCategorias(data);

    }

    useEffect(() => {
        retornaCategorias()
     
    }, [])

    return {
        categorias
    }
}