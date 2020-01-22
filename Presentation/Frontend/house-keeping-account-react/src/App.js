import React, { PureComponent } from 'react';
import House from './Components/House/House'
import './App.css';

class App extends PureComponent {
  state = {
    houses :[
      {cityName: 'Perm', streetName: 'Uinskaya', homeNumber: 1},
      {cityName: 'Perm', streetName: 'U', homeNumber: 1},
      {cityName: 'Perm', streetName: 'My', homeNumber: 1}
    ],
    showHouse : false
  }

  addHouseHandler = () => {
    console.log('Was log clock');
  }

  toggleHouse = () => {
    const doestShow = this.state.showHouse;
    this.setState({showHouse: !doestShow});
  }

  houseChangeHandler = (event) => {
    this.setState({
      houses:[
        {cityName: 'Perm', streetName: 'Uinskaya', homeNumber: 1},
        {cityName: event.target.value, streetName: 'U', homeNumber: 1},
        {cityName: 'Perm', streetName: 'My', homeNumber: 1}
      ]
    })
  }
 
  

  render() {

    let houses = null;

    if (this.state.showHouse)
    {
      houses =
      (<div>
        <House 
          cityName={this.state.houses[0].cityName} 
          streetName={this.state.houses[0].streetName} 
          homeNumber={this.state.houses[0].homeNumber}>          
          </House>
        <House         
          cityName={this.state.houses[1].cityName} 
          streetName={this.state.houses[1].streetName} 
          homeNumber={this.state.houses[1].homeNumber}
          changed={this.houseChangeHandler}>          
        </House>
        <House 
          cityName={this.state.houses[2].cityName} 
          streetName={this.state.houses[2].streetName} 
          homeNumber={this.state.houses[2].homeNumber}>          
        </House>
      </div>)
    }
    return (
    <div className="App">
      <h1>House Keeping Accounting</h1>
      <p>My First Step in SPA</p>
      <button onClick={this.toggleHouse}>Toggle home list</button>
      {houses}      
    </div>
    )
  }
}


export default App;
