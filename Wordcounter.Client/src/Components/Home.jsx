import Switch from "./Switch";
import './Home.css'
import { getWordDensity } from '../Api/api'
import { useState } from "react";
import { useEffect } from "react";

export default function Home() {
    
    const [wordData, setWordData] = useState(null);
    const wordDataDrawer = () => {
        if(!wordData) {
            return <p>Loading...</p>
        }

        return wordData.map(x => (
            <div key={x.id}>
                <p>{x.word}</p>
            </div>
        ))
    }

    const reloadData = () => {
        getWordDensity(12)
            .then(x => setWordData(x));
    }

    return (
        <center>
            <div>
                <h2 className="round-middle background">TOP WORDS DENSITY</h2>
                <div className="divinline">
                    <label>Top</label>&nbsp;
                    <input type="text"
                        id="top"
                        name="top"
                        width="3px"
                        required />
                </div>
                <div className="exclude-checkbox">
                    <Switch/>
                    <label>Exclude Grammar Words</label>
                </div>

                <div>
                    
                </div>
                
                <div>
                    { wordDataDrawer() }
                </div>
                <div>
                    <button onClick={reloadData()}>
                        Request data
                    </button>
                </div>
            </div>
        </center>
    )
}