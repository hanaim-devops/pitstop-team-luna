#!/bin/bash
kubectl apply \
    -f ../prometheus.yaml \
    -f ../alertmanager.yaml