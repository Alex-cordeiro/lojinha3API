import { CustomNavbar } from "../../components/navbar";
import {useEffect} from "react";
import api from "../../Core/api/api";
import { useCategoria } from "./hooks/useCategoria";
import { ButaoRosa, DivAmarela } from "./style";

export function Menu(){
    const {categorias} = useCategoria();
    return (
        <DivAmarela>
            <ButaoRosa>Me clicke safadu!</ButaoRosa>
            {categorias ? categorias.map((item) => {
                return <h2 key={item.id}>{item.nome}</h2> 
            }) : ""}
        </DivAmarela>


    )
}