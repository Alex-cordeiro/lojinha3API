import { useEffect, useState } from "react";
import api from "../../../apis/api";
import { IPermissaoUsuario } from "../../../interfaces/IPermissaoUsuario";

export function usePermissaoMenu() {
  const [permissaoUsuarioMenu, setPermissaoUsuarioMenu] = useState<
    IPermissaoUsuario[]
  >([]);

  async function buscar(id: number) {
    try {
      const { data } = await api.post(
        `PermissaoUsuario/RetornaPermissaoPorUsuario/${id}`
      );
      console.log(data);
      setPermissaoUsuarioMenu(data);
    } catch (error) {
      setPermissaoUsuarioMenu([]);
      alert("Deu rum man!!");
    }
  }

  useEffect(() => {}, []);

  return { buscar, permissaoUsuarioMenu };
}
