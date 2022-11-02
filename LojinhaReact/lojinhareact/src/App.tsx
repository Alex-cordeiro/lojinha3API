import { useState } from "react";
import { ThemeProvider } from "styled-components";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import reactLogo from "./assets/react.svg";
import { CustomNavbar } from "./components/navbar";
import { PrivateRoute } from "./Core/PrivateRoutes";
import { ListarJogo } from "./Pages/Jogo/Listar";
import { RouteJogos } from "./Pages/Jogo/Routes";
import { Menu } from "./Pages/Menu";
import { Unauthorized } from "./Pages/Unauthorized";
import { theme } from "./theme/theme";
import Login from "./Pages/Login";
import Home from "./Pages/Home/Home";

function App() {
  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/Unauthorized" element={<Unauthorized />} />
        </Routes>
      </BrowserRouter>
      <BrowserRouter basename="/menu">
        <PrivateRoute>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/jogo/*" element={<RouteJogos />} />
            <Route path="/desenvolvedoras/*" element={<RouteJogos />} />
          </Routes>
        </PrivateRoute>
      </BrowserRouter>
    </ThemeProvider>
  );
}
export default App;
