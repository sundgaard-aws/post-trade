from flask import Flask, request, jsonify, render_template, send_from_directory
import json
import os

appName="web-api"
app = Flask(appName, template_folder='html',static_folder="static")

@app.route('/api-version', methods=['GET'])
def version_api():
    print("VERSION!")
    response = {'message': 'Success', "response": "1.0.0"}
    return jsonify(response)

@app.route('/api/generateResponse', methods=['POST'])
def generateResponse():
    print("called...")
    data = request.json
    response = {'message': 'Success', "response": generatedResponse}
    return jsonify(response)

@app.route('/', methods=['GET'])
def index():
    #data = request.json
    response = {'message': 'Success'}
    return render_template('index.html')

print("started...")
#app.config['PROPAGATE_EXCEPTIONS'] = True
app.run(debug=True)
#print("run completed.")