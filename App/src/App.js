
import './App.css';
import { FileUpload } from './pages/FileUpload';
import Wanting from './pages/Wanting';
import BottomNav from './pages/BottomNav';
import Navbar from './pages/Navbar';
import Sighter from './pages/Sighter';
import CustomMap from './components/CustomMap';
import { Container } from '@material-ui/core';
import AddWanting from './pages/AddWanting';

function App() {
  return (
    <>
      <Navbar />
      <div className="App"> 

        {/* <FileUpload /> */}
        {/* <Sighter/> */}
        <Wanting/>
      </div>     
      <BottomNav />
    </>
  );
}

export default App;
