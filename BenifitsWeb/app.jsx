

const  textboxstyle = {
    width: '200px'
};


var Modal = React.createClass({
    getInitialState () {
        return { data: {}};
    },
        componentDidMount(){
            $(this.getDOMNode()).modal('show');
            $(this.getDOMNode()).on('hidden.bs.modal', this.props.handleHideModal);
        },
        render() {

            var data = this.props.userData;
            var depen = [];

            for (var i = 0; i < data.Dependents.length; i++) {
                depen.push(
                        <div className="row">
                            <h4>Dependent: {data.Dependents[i].FirstName + " " + data.Dependents[i].LastName}</h4>
                            <label>Benifits Cost: ${data.Dependents[i].BenifitsCost.toFixed(2)} </label>
                        </div> 
                    );
            }

            
        	return (
              <div className="modal fade">
                <div className="modal-dialog">
                  <div className="modal-content">
                    <div className="modal-header">
                      <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <h4 className="modal-title">Employee Benifits</h4>
                    </div>
                    <div className="modal-body">
                        <div className="container">
                            <p>
                            <div className="row">
                                <h4>Employee: {data.Employee.FirstName + " " + data.Employee.LastName}</h4>
                                <label>Benifits Cost: ${data.Employee.BenifitsCost.toFixed(2)} </label>
                            </div>
                            <div className="row">
                                <h4>Employee: {data.Spouse.FirstName + " " + data.Spouse.LastName}</h4>
                                <label>Benifits Cost: ${data.Spouse.BenifitsCost.toFixed(2)} </label>
                            </div>

                                {depen}
                            </p>
                            <p>
                            <span className="clearfix">&nbsp;</span>

                            <div className="row">
                                <label>Total Benifits Cost: ${data.TotalBenifitCost.toFixed(2)} </label>
                                <br />
                                <label>Total Pay After Benifits: ${data.TotalCalculatedPay.toFixed(2)} </label>
                            </div>
                            </p>
                        </div>
                    </div>
                    <div className="modal-footer">
                      <button type="button" className="btn btn-default" data-dismiss="modal">Close</button>                     
                    </div>
                  </div>
                </div>
              </div>
            )
        },
        propTypes:{
        	handleHideModal: React.PropTypes.func.isRequired
        }
    });



  


var Main = React.createClass({
    getInitialState: function () {
        return {
            data: {},
            view: { showModal: false },
            EmployeeFirst: "",
            EmployeeLast: "",
            PayPerPaycheck: "",
            SpouseFirst: "",
            SpouseLast: "",
            DependentsFirst1: "",
            DependentsLast1: "",
            DependentsFirst2: "",
            DependentsLast2: ""
        };
    },
    handleSubmit(e) {
        e.preventDefault();
        var $this = this;
        var currentstate = $this.state;
        var object = {
            CompanyId: 1,
            Employee: {
                FirstName: currentstate.EmployeeFirst,
                LastName: currentstate.EmployeeLast
            },
            Spouse: {
                FirstName: currentstate.SpouseFirst,
                LastName: currentstate.SpouseLast
            },
            Dependents: [{
                FirstName: currentstate.DependentsFirst1,
                LastName: currentstate.DependentsLast1
            }, {
                FirstName: currentstate.DependentsFirst2,
                LastName: currentstate.DependentsLast2
            }],
            PayPerPaycheck: currentstate.PayPerPaycheck            
        }
        



        $.post("http://localhost:57134/api/Calculate", object, function (data) {

            console.log($this.state.data);
            console.log(data);

            $this.setState({ data: data });
            $this.setState({ view: { showModal: true } })
            console.log($this.state.data);


        });
        $this.setState({
            EmployeeFirst: "",
            EmployeeLast: "",
            PayPerPaycheck: "",
            SpouseFirst: "",
            SpouseLast: "",
            DependentsFirst1: "",
            DependentsLast1: "",
            DependentsFirst2: "",
            DependentsLast2: ""
        });

    },
    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    },
    handlePayPerPaycheckChange(e) {
        this.setState({ PayPerPaycheck: e.target.value });
    },

    handleHideModal() {
        this.setState({ view: { showModal: false } })
    },
    moneyvalues(e) {
        const re = /[0-9.{1}0-9{1,2}]+/g;
        if (!re.test(e.key)) {
            e.preventDefault();
        }
    },


    render() {
        return (
            <div id="main">
                <h2>Calculate Pay After Benifits</h2>
                <hr />
                {this.state.view.showModal ? <Modal handleHideModal={this.handleHideModal} userData={this.state.data} /> : null}
                <form onSubmit={this.handleSubmit} >
                    <div className="clearfix container">
                        <div>
                            <h3>Employee</h3>
                            <hr />
                            <div className="form-group col-md-offset-1">
                                <label>First Name</label>
                                <input type="text" className="form-control" value={this.state.EmployeeFirst} style={textboxstyle} onChange={this.handleChange} name="EmployeeFirst" />
                                <label>Last Name</label>
                                <input type="text" className="form-control" value={this.state.EmployeeLast} style={textboxstyle} onChange={this.handleChange} name="EmployeeLast" />
                                <label>Pay Per Check</label>
                                <input type="text" className="form-control" onKeyPress={this.moneyvalues} value={this.state.PayPerPaycheck} style={textboxstyle} onChange={this.handlePayPerPaycheckChange} name="PayPerPaycheck" />
                        </div>
                    </div>
                    <div>
                        <h3>Spouse</h3>
                        <hr />
                        <div className="form-group col-md-offset-1">
                            <label>First Name</label>
                            <input type="text" className="form-control" value={this.state.SpouseFirst} style={textboxstyle} onChange={this.handleChange} name="SpouseFirst"/>
                            <label>Last Name</label>
                            <input type="text" className="form-control" value={this.state.SpouseLast}  style={textboxstyle} onChange={this.handleChange} name="SpouseLast" />
                        </div>

                    </div>
                    <div>
                        <h3>Dependents</h3>
                        <hr />
                            <div className="col-md-offset-1">
                                <h4>Dependent 1</h4>
                                <div className="form-group col-md-offset-1">
                                    <label>First Name</label>
                                    <input type="text" className="form-control" value={this.state.DependentsFirst1} style={textboxstyle} onChange={this.handleChange} name="DependentsFirst1"  />
                                    <label>Last Name</label>
                                    <input type="text" className="form-control" value={this.state.DependentsLast1} style={textboxstyle} onChange={this.handleChange} name="DependentsLast1" />
                                </div>
                                <h4>Dependent 2</h4>
                                <div className="form-group col-md-offset-1">
                                    <label>First Name</label>
                                    <input type="text" className="form-control" value={this.state.DependentsFirst2} style={textboxstyle} onChange={this.handleChange} name="DependentsFirst2" />
                                    <label>Last Name</label>
                                    <input type="text" className="form-control" value={this.state.DependentsLast2} style={textboxstyle} onChange={this.handleChange} name="DependentsLast2" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div className="container">
                        <button className="btn btn-primary">Calculate benifits</button>
                    </div>
                    <div className="clearfix">&nbsp;</div>
                </form>

            </div>
            );
    }
});


React.render(<Main />, document.getElementById('root'));
