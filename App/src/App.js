import './App.css';
import Map from "./Components/MapComponent/MapComponent";
import Frontpage from "./Pages/Frontpage/Frontpage";
import Navbar from "./Components/Navbar/Navbar";
import Container from '@mui/material/Container';
import { createTheme } from '@mui/material/styles';
import { ThemeProvider } from '@emotion/react';
import { Route, Routes } from "react-router-dom";
import BottomNav from './Components/BottomNav/BottomNav';


function App() {

  // Temporary test values
  const kattTheme = createTheme({
    palette: {
      primary: {
        light: '#20c997',
        main: '#0ca678',
        dark: '#087f5b',
        contrastText: '#e6fcf5',

      },
      secondary: {
        light: '#ff7961',
        main: '#f44336',
        dark: '#ba000d',
        contrastText: '#000',
      },
    },
  });


  return (
    <ThemeProvider theme={kattTheme}>

      <Container maxWidth="lg">
        <Navbar />

        <main id="ContentArea">
          <Routes>
            <Route path="" element={<Frontpage />} />
            <Route path="/" element={<Frontpage />} />
            <Route path="/reportsighting" element={<Frontpage />} />
            <Route path="/map" element={<Map />} />
            <Route path="/login" element={<Frontpage />} />
            <Route path="/about" element={<Frontpage />} />
          </Routes>
        </main>

        {/* <footer> */}
        {/* </footer> */}
      </Container>
      <BottomNav />

    </ThemeProvider>
  );
}

export default App;
