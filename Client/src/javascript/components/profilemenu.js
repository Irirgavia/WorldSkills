import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

export class ProfileMenu extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (!this.props.isSignedIn){
            return <ul id="registration">
            <li><a href="https://docs.google.com/forms/d/e/1FAIpQLSdyPuXOouBLsxRCG3tiQTruitJjgcmV3Zlv17RZMSDIRXjEtQ/viewform?usp=sf_link">Регистрация на участие</a></li>
            <li id="profilemenu" class="down"><Link to="/signin" id="accountlink">Вход</Link>
                
            </li>
        </ul>
        } else if(this.props.user.role=="participant"){
            return <ul id="registration">
                <li id="profilemenu" class="down">{this.props.user.name}
                    <ul class="submenu">
                        <li><Link to="/participant/personaldata">Личные данные</Link></li>
                        <li><Link to="/participant/results">Результаты</Link></li>
                        <li><Link to="/participant/competitions">Текущие соревнования</Link></li>
                        <li><Link to="/signout">Выйти</Link></li>
                    </ul>
                </li>
            </ul>
        } else if(this.props.user.role=="judge"){
            return <ul id="registration">
                <li id="profilemenu" class="down">{this.props.user.name}
                    <ul class="submenu">
                        <li><Link to="/judge/personaldata">Личные данные</Link></li>
                        <li><Link to="/judge/tasks">Задания</Link></li>
                        <li><Link to="/judge/answers">Ответы</Link></li>
                        <li><Link to="/signout">Выйти</Link></li>
                    </ul>
                </li>
            </ul>
        } else if(this.props.user.role=="trainer"){
            return <ul id="registration">
                <li id="profilemenu" class="down">{this.props.user.name}
                    <ul class="submenu">
                        <li><Link to="/trainer/personaldata">Личные данные</Link></li>
                        <li><Link to="/profile/trainer/results">Результаты команд</Link></li>
                        <li><Link to="/signout">Выйти</Link></li>
                    </ul>
                </li>
            </ul>
        } else if(this.props.user.role=="administrator"){
            return <ul id="registration">
                <li id="profilemenu" class="down">{this.props.user.name}
                    <ul class="submenu">
                        <li><Link to="/administrator/personaldata">Личные данные</Link></li>
                        <li><Link to="/signout">Выйти</Link></li>
                    </ul>
                </li>
            </ul>
            }
        }
    }

    let mapProps = (state) => {
      return {
          user: state.user,
          isSignedIn: state.isSignedIn
      }
  }
  
  export default connect(mapProps)(ProfileMenu)