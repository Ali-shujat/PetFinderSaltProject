
import './App.css';
import { FileUpload } from './FileUpload';
import Wanting from './pages/Wanting';
import LabelBottomNavigation from './pages/LabelBottomNavigation';
import Navbar from './pages/Navbar';

function App() {
  return (
    <>
    <Navbar />
      <div className="App">
       
        <FileUpload />
      </div> 
      <LabelBottomNavigation />
    </>
  );
}

export default App;
