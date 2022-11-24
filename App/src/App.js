
import './App.css';
import { FileUpload } from './pages/FileUpload';
import Wanting from './pages/Wanting';
import BottomNav from './pages/BottomNav';
import Navbar from './pages/Navbar';
import Sighter from './pages/Sighter';
import CustomMap from './components/CustomMap';
import { Container } from '@material-ui/core';
import { createTheme } from '@mui/material/styles';
import { ThemeProvider } from '@emotion/react';
import { Route, Routes } from "react-router-dom";
import AddWanting from './pages/AddWanting';

function App() {
  // Temporary test values
  const kattTheme = createTheme({
    palette: {
      primary: {
        light: '#e2a2b4',
        main: '#c44569',
        dark: '#622335',
        contrastText: '#fff5e2',

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
    <>
      <Navbar />
      <div className="App"> 
{/* <AddWanting/> */}
        {/* <FileUpload /> */}
        {/* <Sighter/> */}
        <Wanting/>
      </div>     
      <BottomNav />
    </>
  );
}

export default App;
