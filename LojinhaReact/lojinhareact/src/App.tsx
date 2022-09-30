import { useState } from 'react'
import { ThemeProvider } from 'styled-components'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import reactLogo from './assets/react.svg'
import { CustomNavbar } from './components/navbar'
import { PrivateRoute } from './Core/PrivateRoutes'
import { ListarJogo } from './Pages/Jogo/Listar'
import { RouteJogos } from './Pages/Jogo/Routes'
import { Menu } from './Pages/Menu'
import { Unauthorized } from './Pages/Unauthorized'
import { theme } from './theme/theme'
import { CustomSideBar } from './components/sidebar'


function App() {


  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<CustomSideBar/>}/>
          <Route path='/Menu' element={<PrivateRoute><Menu /></PrivateRoute>} />
          <Route path='/jogo/*' element={<PrivateRoute><RouteJogos /></PrivateRoute>} />
          <Route path='/Unauthorized' element={<Unauthorized />} />
        </Routes>
      </BrowserRouter>
    </ThemeProvider>

  )
}

export default App
