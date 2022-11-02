import { Navigate } from "react-router-dom";
import { Tela } from "../../components/tela";
import { Menu } from "../../Pages/Menu";

interface Props {
  children: any;
}

export const PrivateRoute = (props: Props) => {
  const token = localStorage.getItem("@token");

  if (!token) {
    return <Navigate to="/Unauthorized" />;
  }

  return <Menu>{props.children}</Menu>;
};