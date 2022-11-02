import { useEffect } from "react";
import { Link } from "react-router-dom";
import { usePermissaoMenu } from "../../Pages/Menu/hooks/usePermissaoMenu";
import { StyledSidebar } from "./style";

export function Sidebar() {
  const { buscar, permissaoUsuarioMenu } = usePermissaoMenu();

  useEffect(() => {
    buscar(1);
  }, []);

  return (
    <StyledSidebar>
      <ul>
        {permissaoUsuarioMenu
          ? permissaoUsuarioMenu.map((data, index) => {
              return (
                <li>
                  <Link to={data.menu.caminho}>
                    <span className="icon">
                      <i className="fas fa-home"></i>
                    </span>
                    <span className="item">{data.menu.nome}</span>
                  </Link>
                </li>
              );
            })
          : ""}
      </ul>
    </StyledSidebar>
  );
}
