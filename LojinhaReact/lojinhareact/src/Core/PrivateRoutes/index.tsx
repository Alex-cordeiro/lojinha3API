import { Navigate } from "react-router-dom";
import { Tela } from "../../components/tela";

interface Props {
  children: any;
}

export const PrivateRoute = (props: Props) => {
  const token = localStorage.getItem("@token");

  if (!token) {
    return <Navigate to="/Unauthorized" />;
  }

  return <Tela>{props.children}</Tela>;
};