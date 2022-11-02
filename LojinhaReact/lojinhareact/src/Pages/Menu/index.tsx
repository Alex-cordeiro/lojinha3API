import { CustomNavbar } from "../../components/navbar";
import { useEffect } from "react";
import { usePermissaoMenu } from "./hooks/usePermissaoMenu";
import { ButaoRosa, DivAmarela } from "./style";
import { Wrapper } from "../../components/sidebar/style";
import { Sidebar } from "../../components/sidebar";

export function Menu({ children }: any) {
  return (
    <>
      <Wrapper>
        <Sidebar />
        <div style={{ backgroundColor: "black" }}>{children}</div>
      </Wrapper>
    </>
  );
}
