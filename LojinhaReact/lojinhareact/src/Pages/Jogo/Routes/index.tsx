import { Routes, Route } from "react-router-dom";
import { CadastrarJogo } from "../Cadastro";
import { ListarJogo } from "../Listar";

export function RouteJogos() {
  return (
    <Routes>
      <Route path="lista" element={<ListarJogo />} />
      <Route path="cadastro" element={<CadastrarJogo />} />
    </Routes>
  );
}
